using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LoginRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Authentications;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.LoginRepository;

public class GetLoginRepository : IGetLoginRepository
{
    private readonly IAppDbContext _context;
    private readonly JwtOptions _jwtOptions;
    private readonly IAuthService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetLoginRepository(IAppDbContext context, IOptions<JwtOptions> jwtOptions, IAuthService authService, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _jwtOptions = jwtOptions.Value;
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task GetLoginAsync(UserDto request, CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.RefreshTokens
                    .Where(x => x.ExpiresAt <= DateTime.UtcNow)
                    .ExecuteDeleteAsync(cancellationToken);

            var accessToken = _authService.GenerateJwtToken(request);
            var refreshToken = _authService.GenerateRefreshToken();

            var existingToken = await _context.RefreshTokens
                    .FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);

            if (existingToken != null)
            {
                existingToken.Token = refreshToken;
                existingToken.ExpiresAt = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenDays);
                existingToken.RevokedAt = null;

                _context.RefreshTokens.Update(existingToken);
            }
            else
            {
                await _context.RefreshTokens.AddAsync(new RefreshToken
                {
                    UserId = request.UserId,
                    Token = refreshToken,
                    ExpiresAt = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenDays),
                    RevokedAt = null
                }, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken);

            _authService.SetAccessTokenCookie(accessToken);
            _authService.SetRefreshTokenCookie(refreshToken);
        }
        catch (DbUpdateException ex)
        {
            var innerMessage = ex.InnerException?.Message;

            // log ke console / logger
            Console.WriteLine(innerMessage);

            throw new Exception(innerMessage ?? "Database update failed", ex);
        }
    }
}
