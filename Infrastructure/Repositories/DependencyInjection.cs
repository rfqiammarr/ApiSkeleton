using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LoginRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LogoutRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RefreshTokenRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RegisterRepository;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.LoginRepository;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.LogoutRepository;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories.Users.RefreshTokenRepository;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Users.RegisterRepository;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
         services.AddScoped<IGetLoginRepository, GetLoginRepository>();
         services.AddScoped<IGetRefreshTokenRepository, GetRefreshTokenRepository>();
         services.AddScoped<ILogoutRepository, LogoutRepository>();
         services.AddScoped<ICreateRegisterRepository, CreateRegisterRepository>();

        return services;
    }
}
