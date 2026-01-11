using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Helpers;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Masters.Permissions;

public sealed class PermissionRepository(IAppDbContext _context, IHttpContextAccessor _httpContextAccessor) : IPermissionRepository
{
    public async Task<PermissionDto> CreatePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        var isPermissionExist = await _context.Permissions
            .AnyAsync(x => x.PermissionCode == permissionDto.PermissionCode && !x.IsDeleted, cancellationToken);

        if (isPermissionExist)
            throw new BadRequestException("Permission already exists.");

       var permission = new Permission
        {
            PermissionCode = permissionDto.PermissionCode,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = GetClaimFor.GetUsername(_httpContextAccessor) ?? "System",
        };

        _ = await _context.Permissions.AddAsync(permission, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);

        return new PermissionDto
        {
            PermissionId = permission.PermissionId,
            PermissionCode = permission.PermissionCode,
            CreatedAt = permission.CreatedAt,
            CreatedBy = permission.CreatedBy,
        };
    }

    public async Task DeletePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        var permission = await _context.Permissions
            .FirstOrDefaultAsync(x => x.PermissionId == permissionDto.PermissionId && !x.IsDeleted, cancellationToken);

        if (permission == null)
            throw new NotFoundException("Permission not found.");
        
        permission.IsDeleted = true;
        permission.Modified = DateTime.UtcNow;
        permission.ModifiedBy = GetClaimFor.GetUsername(_httpContextAccessor) ?? "System";
        
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<PermissionDto>> GetManyPermissionsRepository(CancellationToken cancellationToken)
    {
        var permissions = await _context.Permissions
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
            })
            .ToListAsync(cancellationToken);

        return permissions;
    }

    public async Task<PermissionDto> GetOnePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        var permission = await _context.Permissions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.PermissionId == permissionDto.PermissionId && !x.IsDeleted, cancellationToken);
        if (permission == null)
            throw new NotFoundException("Permission not found.");
        return new PermissionDto
        {
            PermissionId = permission.PermissionId,
            PermissionCode = permission.PermissionCode,
            CreatedAt = permission.CreatedAt,
            CreatedBy = permission.CreatedBy,
            Modified = permission.Modified,
            ModifiedBy = permission.ModifiedBy
        };
    }

    public async Task<PermissionDto> UpdatePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        var permission = await _context.Permissions
            .FirstOrDefaultAsync(x => x.PermissionId == permissionDto.PermissionId && !x.IsDeleted, cancellationToken);
        
        if (permission == null)
            throw new NotFoundException("Permission not found.");
        
        permission.PermissionCode = permissionDto.PermissionCode;
        permission.Modified = DateTime.UtcNow;
        permission.ModifiedBy = GetClaimFor.GetUsername(_httpContextAccessor) ?? "System";
        
        _ =  await _context.SaveChangesAsync(cancellationToken);
        
        return new PermissionDto
        {
            PermissionId = permission.PermissionId,
            PermissionCode =  permission.PermissionCode,
            CreatedAt = permission.CreatedAt,
            CreatedBy = permission.CreatedBy,
            Modified = permission.Modified,
            ModifiedBy = permission.ModifiedBy
        };
    }
}
