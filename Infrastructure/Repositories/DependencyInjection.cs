using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Role.GetManyRolesRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LogoutRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RefreshTokenRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RegisterRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.UserRepository;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.LogoutRepository;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.RefreshTokenRepository;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Masters.Roles.GetManyRolesRepository;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Users.RegisterRepository;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Users.UserRepository;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        #region Authentication
         services.AddScoped<IUserRepository, UserRepository>();
         services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
         services.AddScoped<ILogoutRepository, LogoutRepository>();
         services.AddScoped<ICreateRegisterRepository, CreateRegisterRepository>();
        #endregion
        #region Masters
        services.AddScoped<IGetManyRolesRepository, GetManyRolesRepository>();
        #endregion
        return services;
    }
}
