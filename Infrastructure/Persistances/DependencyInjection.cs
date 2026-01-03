using Application.Interfaces.Services.Persistance;
using Infrastructure.Persistances;
using Infrastructure.Persistances.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSkeleton.Infrastructure.Persistances;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseOptions = configuration.GetSection("DatabaseOptions").Get<DatabaseOptions>()!;
        var migrationsAssembly = typeof(ApplicationDbContext).Assembly.FullName;

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(databaseOptions.ConnectionString, builder =>
            {
                builder.MigrationsAssembly(migrationsAssembly);
                builder.MigrationsHistoryTable("MigrationLogs", nameof(ApiSkeleton));
                builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            options.ConfigureWarnings(cw => cw.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
            options.ConfigureWarnings(cw => cw.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
        });

        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
