using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Application.Services;

namespace RifqiAmmarR.ApiSkeleton.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        // Dependency injection registrations go here
        service.AddFeaturesServices();

        return service;
    }
}
