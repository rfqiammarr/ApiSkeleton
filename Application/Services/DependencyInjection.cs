using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Role.GetManyRoles;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Login;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Logout;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.RefreshToken;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Register;
using RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.GetRefreshToken;
using RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Login;
using RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Logout;
using RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Register;
using RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Roles.GetManyRoles;

namespace RifqiAmmarR.ApiSkeleton.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesServices(this IServiceCollection service)
    {
        // Add application services here
        #region Authentication
        service.AddScoped<IRegisterAsync, CreateRegisterCommand>();
        service.AddScoped<ILoginAsync, CreateLoginCommand>();
        service.AddScoped<IGetRefreshToken, GetRefreshTokenService>();
        service.AddScoped<ILogoutAsync, LogoutAsync>();
        #endregion
        #region Masters
        service.AddScoped<IGetManyRolesQuery, GetManyRolesQuery>();
        #endregion

        return service;
    }
}
