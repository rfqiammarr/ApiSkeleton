using ApiSkeleton.Infrastructure.Persistances;
using Infrastructure.Authentications;
using Infrastructure.CORS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Securities;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsService(configuration);
        services.AddPersistence(configuration);
        services.AddAuthenticationService(configuration);
        services.AddSecurities();

        return services;
    }
}
