using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LogoutRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using System.Security.Claims;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.LogoutRepository;

public class LogoutRepository : ILogoutRepository
{
    private readonly IAppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogoutRepository(
        IAppDbContext context,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Handle(CancellationToken cancellationToken = default)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null)
            return;

        var userIdClaim = httpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var userId))
            return;

        var token = await _context.RefreshTokens
            .FirstOrDefaultAsync(
                x => x.UserId == userId && x.RevokedAt == null,
                cancellationToken);

        if (token != null)
        {
            _context.RefreshTokens.Remove(token);
            await _context.SaveChangesAsync(cancellationToken);
        }

        httpContext.Response.Cookies.Delete("access_token");
        httpContext.Response.Cookies.Delete("refresh_token");
    }
}
