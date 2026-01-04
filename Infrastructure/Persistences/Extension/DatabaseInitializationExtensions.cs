using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.DataContext;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.Seeders;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.Extension;

public static class DatabaseInitializationExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var env = app.Environment;
        var options = scope.ServiceProvider
            .GetRequiredService<IOptions<DatabaseInitializationOptions>>()
            .Value;

        // 🚨 HARD SAFETY GUARD
        if (env.IsProduction() && options.EnableSeed)
        {
            throw new InvalidOperationException(
                "Database seeding is NOT allowed in Production environment.");
        }

        if (!options.EnableMigration && !options.EnableSeed)
            return;

        var db = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        if (options.EnableMigration)
        {
            app.Logger.LogInformation("Applying database migrations...");
            await db.Database.MigrateAsync();
        }

        if (options.EnableSeed)
        {
            app.Logger.LogInformation("Running database seeders...");
            await SeederRunner.RunAsync(db);
        }
    }
}

