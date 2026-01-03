using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Services.Persistance;

public interface IAppDbContext
{
    #region Users
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    #endregion

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
