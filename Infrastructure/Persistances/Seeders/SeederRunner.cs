using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistances.DataContext;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Persistances.Seeders;

public static class SeederRunner
{
    public static async Task RunAsync(ApplicationDbContext db)
    {
        await RolePermissionSeeder.SeedAsync(db);

        // nanti kalau nambah:
        // await DefaultAdminSeeder.SeedAsync(db);
    }
}

