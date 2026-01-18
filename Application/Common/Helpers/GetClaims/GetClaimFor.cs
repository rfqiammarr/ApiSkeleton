using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RifqiAmmarR.ApiSkeleton.Application.Common.Helpers.GetClaims;

public static class GetClaimFor
{
    public static string? GetUsername(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext == null)
            return "System";

        return httpContextAccessor.HttpContext?
            .User?
            .FindFirst(ClaimTypes.Name)?.ValueType;
    }

    public static string? GetUserId(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext == null)
           return "System";

        return httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.ValueType;
    }
}