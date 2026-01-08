using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RifqiAmmarR.ApiSkeleton.Application.Common.Helpers.HttpContext;

public static class GetClaimFor
{
    public static string? GetUsername(IHttpContextAccessor httpContextAccessor)
    {
       return httpContextAccessor.HttpContext?
            .User?
            .FindFirst(ClaimTypes.Name)?.ValueType;
    }
}