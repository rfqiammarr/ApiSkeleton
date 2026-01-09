using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Roles;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Helpers;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Masters.Roles;

public class RoleRepository(IAppDbContext _context, IHttpContextAccessor _httpContextAccessor) : IRolesRepository
{
    public async Task<RoleDto> CreateRoleRepository(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var isRoleExist = await _context.Roles
            .AsNoTracking()
            .AnyAsync(x => x.RoleId == roleDto.RoleId, cancellationToken);

        if(isRoleExist)
            throw new BadRequestException("Role already exists.");

        var createdBy = GetClaimFor.GetUsername(_httpContextAccessor);

        var role = new Role
        {
            RoleName = roleDto.RoleName,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = createdBy,
            IsDeleted = false
        };

        _ = await _context.Roles.AddAsync(role, cancellationToken);
        _ = await _context.SaveChangesAsync(cancellationToken);
        
        return new RoleDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
            CreatedAt = role.CreatedAt,
            CreatedBy = role.CreatedBy,
            IsDeleted = role.IsDeleted
        };
    }

    public async Task DeleteRoleRepository(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = _context.Roles
            .FirstOrDefault(x => x.RoleId == roleDto.RoleId && !x.IsDeleted);
        
        if (role == null)
            throw new NotFoundException("Role not found.");
        role.IsDeleted = true;
        role.Modified =  DateTime.UtcNow;
        role.ModifiedBy = GetClaimFor.GetUsername(_httpContextAccessor);
        
        _ = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<RoleDto>> GetManyRolesRepository(CancellationToken cancellationToken)
    {
        var data = await _context.Roles
            .AsNoTracking()
            .Where(x => !x.IsDeleted )
            .Select(role => new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                CreatedAt = role.CreatedAt,
                CreatedBy = role.CreatedBy,
                IsDeleted = role.IsDeleted,
                Modified = role.Modified,
                ModifiedBy = role.ModifiedBy
            })
            .ToListAsync(cancellationToken);

        return data;
    }

    public async Task<RoleDto> GetOneRoleRepository(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = await _context.Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.RoleId == roleDto.RoleId && !x.IsDeleted, cancellationToken);
        
        if (role == null)
            throw new NotFoundException("Role not found.");

        return new RoleDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
        };
    }

    public async Task<RoleDto> UpdateRoleRepository(RoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(x => x.RoleId == roleDto.RoleId && !x.IsDeleted, cancellationToken);

        if (role == null)
            throw new NotFoundException("Role not found.");

        role.RoleName = roleDto.RoleName;
        role.Modified = DateTime.UtcNow;
        role.ModifiedBy = GetClaimFor.GetUsername(_httpContextAccessor);
        
        _ = await _context.SaveChangesAsync(cancellationToken);

        return new RoleDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
            CreatedAt = role.CreatedAt,
            CreatedBy = role.CreatedBy,
            IsDeleted = role.IsDeleted,
            Modified = role.Modified,
            ModifiedBy = role.ModifiedBy
        };
    }
}
