using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.DataContext;

public class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Ambil environment (Development default)
        var environment =
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? "Development";

        // Build configuration
        var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true)
             .AddJsonFile($"appsettings.{environment}.json", optional: true)
             .AddEnvironmentVariables()
             .Build();

        var connectionString =
            configuration.GetSection("DatabaseOptions")
                 .Get<DatabaseOptions>()?.ConnectionString
    ?? throw new InvalidOperationException("Connection string not found");

        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseNpgsql(connectionString, builder =>
        {
            builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            builder.MigrationsHistoryTable("MigrationLogs", nameof(ApiSkeleton));
        });

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
