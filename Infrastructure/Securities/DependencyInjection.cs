using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Security;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Securities;

public static class DependencyInjection
{
    public static IServiceCollection AddSecurities(this IServiceCollection service)
    {
        service.AddSingleton<IPasswordHasher, Argon2PasswordHasher>();
        return service;
    }
}
