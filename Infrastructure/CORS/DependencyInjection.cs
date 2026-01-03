using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CORS;

public static class DependencyInjection
{
    public static IServiceCollection AddCorsService(this IServiceCollection service, IConfiguration configuration)
    {
        var corsOptions = configuration.GetSection(nameof(CorsOptions)).Get<CorsOptions>()
            ?? throw new InvalidOperationException("CorsOptions not configured");

        service.AddCors(options =>
        {
            options.AddPolicy(corsOptions.PolicyName, policy =>
            {
                policy.WithOrigins(corsOptions.AllowedOrigins)
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
            });
        });

        return service;
    }

}
