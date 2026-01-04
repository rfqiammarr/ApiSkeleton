using Application.Interfaces.Services.Persistance;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using System.Reflection;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Persistances.DataContext;

public class ApplicationDbContext : DbContext, IAppDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    #region User
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    #endregion

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //  otomatis load semua konfigurasi di assembly 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
