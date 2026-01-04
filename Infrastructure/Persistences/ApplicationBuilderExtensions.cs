using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.DataContext;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.Seeders;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences;

public static class ApplicationBuilderExtensions
{
    public static async Task ApplyMigrationsAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await db.Database.MigrateAsync();
        await RolePermissionSeeder.SeedAsync(db);
    }
}

