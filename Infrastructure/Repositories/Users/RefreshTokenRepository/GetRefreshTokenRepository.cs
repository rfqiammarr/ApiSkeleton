using Application.Interfaces.Services.Persistance;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using Infrastructure.Authentications;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RefreshTokenRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.RefreshTokenRepository;

public class GetRefreshTokenRepository : IGetRefreshTokenRepository
{
    private readonly IAppDbContext _context;
    private readonly JwtOptions _jwtOptions;
    private readonly IAuthService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetRefreshTokenRepository(IAppDbContext context, IOptions<JwtOptions> jwtOptions, IAuthService authService, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _jwtOptions = jwtOptions.Value;
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Handle(CancellationToken cancellationToken)
    {
        var refreshToken = _httpContextAccessor.HttpContext?.Request.Cookies["refresh_token"];
        if (string.IsNullOrEmpty(refreshToken))
            throw new UnauthorizedAccessException("Invalid credentials");

        var tokenEntity = await _context.RefreshTokens
            .FirstOrDefaultAsync(x =>
                x.Token == refreshToken &&
                x.RevokedAt == null &&
                x.ExpiresAt > DateTime.UtcNow);

        if (tokenEntity == null)
            throw new UnauthorizedAccessException("Invalid credentials");

        var user = await _context.Users
                    .Include(x => x.Role)
                    .Include(x => x.Permission)
                    .FirstOrDefaultAsync(
                        x => x.Id == tokenEntity.UserId,
                        cancellationToken
                    );

        if (user == null)
            throw new UnauthorizedAccessException("Invalid credentials");

        UserDto userDto = new UserDto()
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            RoleName = user.Role.RoleName,
            PermissionCode = user.Permission.PermissionCode,
        };

        // 🔁 Rotate refresh token
        tokenEntity.RevokedAt = DateTime.UtcNow;

        var newRefreshToken = _authService.GenerateRefreshToken();
        await _context.RefreshTokens.AddAsync(new RefreshToken
        {
            UserId = user.Id,
            Token = newRefreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(
                _jwtOptions.RefreshTokenDays)
        }, cancellationToken);

        var newAccessToken = _authService.GenerateJwtToken(userDto);

        await _context.SaveChangesAsync(cancellationToken);

        _authService.SetAccessTokenCookie(newAccessToken);
        _authService.SetRefreshTokenCookie(newRefreshToken);
    }
}
