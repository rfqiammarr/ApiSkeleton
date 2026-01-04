using Application.Interfaces.Services.Persistance;
using Infrastructure.Authentications;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LogoutRepository;
using System.Security.Claims;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.LogoutRepository;

public class LogoutRepository : ILogoutRepository
{
    private readonly IAppDbContext _context;
    private readonly JwtOptions _jwtOptions;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogoutRepository(
        IAppDbContext context,
        IOptions<JwtOptions> jwtOptions,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _jwtOptions = jwtOptions.Value;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Handle()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
            throw new InvalidOperationException("HttpContext tidak tersedia");

        var userIdClaim = httpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userIdClaim))
            throw new UnauthorizedAccessException("User tidak terautentikasi");

        var userId = Guid.Parse(userIdClaim);

        var tokens = await _context.RefreshTokens
            .Where(x => x.UserId == userId && x.RevokedAt == null)
            .ToListAsync();

        foreach (var token in tokens)
        {
            token.RevokedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();

        httpContext.Response.Cookies.Delete("access_token");
        httpContext.Response.Cookies.Delete("refresh_token");
    }
}
