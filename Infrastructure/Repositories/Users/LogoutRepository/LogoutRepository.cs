using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Common.Helpers.GetClaims;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LogoutRepository;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.DataContext;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.LogoutRepository;

public class LogoutRepository(
    IAppDbContext context,
    IHttpContextAccessor httpContextAccessor) : ILogoutRepository
{
    public async Task Handle(CancellationToken cancellationToken = default)
    {
        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext == null)
            return;

        var userIdClaim = GetClaimFor.GetUserId(httpContextAccessor);

        if (!Guid.TryParse(userIdClaim, out var userId))
            return;

        var token = await context.RefreshTokens
            .FirstOrDefaultAsync(
                x => x.UserId == userId && x.RevokedAt == null,
                cancellationToken);

        if (token != null)
        {
            context.RefreshTokens.Remove(token);
            await context.SaveChangesAsync(cancellationToken);
        }

        httpContext.Response.Cookies.Delete("access_token");
        httpContext.Response.Cookies.Delete("refresh_token");
    }
}
