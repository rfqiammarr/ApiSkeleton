using Infrastructure.Authentications;
using Infrastructure.CORS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Securities;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistances;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsService(configuration);
        services.AddPersistence(configuration);
        services.AddAuthenticationService(configuration);
        services.AddSecurities();
        services.AddRepositoryServices();

        return services;
    }
}
