using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;

public interface IAppDbContext
{
    #region Users
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    #endregion

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
