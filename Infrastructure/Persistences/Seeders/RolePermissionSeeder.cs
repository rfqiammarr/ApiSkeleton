using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.SeedData;
using System.Security.Claims;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Persistences.Seeders;

public static class RolePermissionSeeder
{
    public static async Task SeedAsync(IAppDbContext context)
    {
        // 1️⃣ Roles
        foreach (var roleName in DefaultRolesPermissions.Roles)
        {
            if (!context.Roles.Any(r => r.RoleName == roleName))
            {
                context.Roles.Add(new Role
                {
                    RoleName = roleName,
                    CreatedBy = ClaimTypes.Name,
                });
            }
        }

        await context.SaveChangesAsync();

        // 2️⃣ Permissions
        foreach (var permissionCode in DefaultRolesPermissions.Permissions)
        {
            if (!context.Permissions.Any(p => p.PermissionCode == permissionCode))
            {
                context.Permissions.Add(new Permission
                {
                    PermissionCode = permissionCode,
                    CreatedBy = ClaimTypes.Name,
                });
            }
        }

        await context.SaveChangesAsync();

        // 3️⃣ Role ↔ Permission
        foreach (var mapping in DefaultRolesPermissions.RolePermissions)
        {
            var role = context.Roles.First(r => r.RoleName == mapping.Key);

            foreach (var permissionCode in mapping.Value)
            {
                var permission = context.Permissions.First(p => p.PermissionCode == permissionCode);

                if (!context.RolePermissions.Any(rp =>
                        rp.RoleId == role.RoleId &&
                        rp.PermissionId == permission.PermissionId))
                {
                    context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = role.RoleId,
                        PermissionId = permission.PermissionId,
                    });
                }
            }
        }

        await context.SaveChangesAsync();
    }
}