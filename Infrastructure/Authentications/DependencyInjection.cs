using Infrastructure.Authentications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Authentications;
using System.Text;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Authentications;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthenticationService(this IServiceCollection service, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()
            ?? throw new InvalidOperationException("JwtOptions not configured");

        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = Constants.ValidateIssuer,
                ValidateAudience = Constants.ValidateAudience,
                ValidateLifetime = Constants.ValidateLifetime,
                ValidateIssuerSigningKey = Constants.ValidateIssuerSigningKey,

                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtOptions.Key!)
                )
            };


            // Ambil JWT dari HttpOnly Cookie
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies[Constants.CookiesRequest];
                    return Task.CompletedTask;
                }
            };
        });

        service.AddAuthorizationBuilder()
            .AddPolicy("RequireManager", policy =>
                policy.RequireRole("Manager", "Admin"));

        service.AddScoped<IAuthService, AuthService>();
        service.AddHttpContextAccessor();

        return service;
    }
}
