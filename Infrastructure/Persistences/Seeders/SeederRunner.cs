using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.DataContext;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.Seeders;

public static class SeederRunner
{
    public static async Task RunAsync(ApplicationDbContext db)
    {
        await RolePermissionSeeder.SeedAsync(db);

        // nanti kalau nambah:
        // await DefaultAdminSeeder.SeedAsync(db);
    }
}

