using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Common.Extensions;
using RifqiAmmarR.ApiSkeleton.Application.Common.Responses;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Permissions;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.DataContext;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Masters.Permissions;

public sealed class PermissionRepository(IAppDbContext _context) : IPermissionRepository
{
    public async Task CreatePermissionRepository(Permission entity, CancellationToken cancellationToken)
    {
        await _context.Permissions.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task PermanentDeletePermissionRepository(Permission entityData, CancellationToken cancellationToken)
    {
        _context.Permissions.Remove(entityData);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginatedListResponse<PermissionDto>> GetManyPermissionsRepository(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = _context.Permissions
          .AsNoTracking()
          .Where(x => !x.IsDeleted)
          .Select(x => new PermissionDto
          {
              PermissionId = x.PermissionId,
              PermissionCode = x.PermissionCode,
              CreatedAt = x.CreatedAt,
              CreatedBy = x.CreatedBy,
              Modified = x.Modified,
              ModifiedBy = x.ModifiedBy
          });

        return await query
            .OrderBy(x => x.PermissionCode)
            .ToPaginatedListAsync(pageNumber, pageSize, cancellationToken);
    }

    public async Task<PermissionDto?> GetOnePermissionByIdRepository(int id, CancellationToken cancellationToken)
    {
        return await _context.Permissions.AsNoTracking()
        .Where(x => x.PermissionId == id && !x.IsDeleted)
        .Select(x => new PermissionDto
        {
            PermissionId = x.PermissionId,
            PermissionCode = x.PermissionCode,
            CreatedAt = x.CreatedAt,
            CreatedBy = x.CreatedBy,
            Modified = x.Modified,
            ModifiedBy = x.ModifiedBy
        })
        .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<Permission?> GetOnePermissionByIdForUpdateRepository(int id, CancellationToken cancellationToken)
    {
        return await _context.Permissions
            .SingleOrDefaultAsync(
                x => x.PermissionId == id && !x.IsDeleted,
                cancellationToken);
    }

    public async Task UpdatePermissionRepository(Permission permission, CancellationToken cancellationToken)
    {
        _context.Permissions.Update(permission);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsPermissionDataExistRepository(string name, CancellationToken cancellationToken)
    {
         return await _context.Permissions
            .AnyAsync(x => x.PermissionCode == name && !x.IsDeleted, cancellationToken);
    }
}