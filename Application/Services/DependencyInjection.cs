using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.Register;
using RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Register;

namespace RifqiAmmarR.ApiSkeleton.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesServices(this IServiceCollection service)
    {
        // Add application services here
        #region Authentication
        service.AddScoped<IRegisterAsync, CreateRegisterCommand>();
        #endregion


        return service;
    }
}
