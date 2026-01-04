using Application.Interfaces.Services.Persistance;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using Infrastructure.Authentications;
using Microsoft.Extensions.Options;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LoginRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.LoginRepository;

public class GetLoginRepository : IGetLoginRepository
{
    private readonly IAppDbContext _context;
    private readonly JwtOptions _jwtOptions;
    private readonly IAuthService _authService;

    public GetLoginRepository(IAppDbContext context, IOptions<JwtOptions> jwtOptions, IAuthService authService)
    {
        _context = context;
        _jwtOptions = jwtOptions.Value;
        _authService = authService;
    }

    public async Task GetLoginAsync(UserDto request, CancellationToken cancellationToken = default)
    {
        var accessToken = _authService.GenerateJwtToken(request);
        var refreshToken = _authService.GenerateRefreshToken();

        await _context.RefreshTokens.AddAsync(new RefreshToken
        {
            UserId = request.UserId,
            Token = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(
                _jwtOptions.RefreshTokenDays)
        }, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        _authService.SetAccessTokenCookie(accessToken);
        _authService.SetRefreshTokenCookie(refreshToken);
    }
}
