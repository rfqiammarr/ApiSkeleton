using Microsoft.AspNetCore.Http;
using RifqiAmmarR.ApiSkeleton.Application.Common.Exceptions;
using RifqiAmmarR.ApiSkeleton.Application.Common.Helpers.GetClaims;
using RifqiAmmarR.ApiSkeleton.Application.Common.Responses;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Permissions;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Permissions;

public sealed class PermissionService(IPermissionRepository _permissionRepository, IHttpContextAccessor _httpContextAccessor) : IPermissionService
{
    public async Task<PermissionDto> CreatePermissionService(PermissionDto request, CancellationToken cancellationToken)
    {
        var isExist = await _permissionRepository
            .IsPermissionDataExistRepository(
                request.PermissionCode,
                cancellationToken);

        if (isExist)
            throw new BadRequestException("Permission already exists.");

        var entity = new Permission
        {
            PermissionCode = request.PermissionCode,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = GetClaimFor.GetUsername(_httpContextAccessor)
        };

        await _permissionRepository
            .CreatePermissionRepository(entity, cancellationToken);

        return new PermissionDto
        {
            PermissionId = entity.PermissionId,
            PermissionCode = entity.PermissionCode,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy
        };
    }

    public async Task DeletePermissionService(int id, CancellationToken cancellationToken)
    {
        var data = await _permissionRepository
            .GetOnePermissionByIdForUpdateRepository(id, cancellationToken);

        if (data == null)
            throw new BadRequestException("Permission not found.");

        data.IsDeleted = true;
        data.Modified = DateTime.UtcNow;
        data.ModifiedBy = GetClaimFor.GetUsername(_httpContextAccessor);

        await _permissionRepository.UpdatePermissionRepository(data, cancellationToken);
    }

    public async Task<PaginatedListResponse<PermissionDto>> GetPermissionsService(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetManyPermissionsRepository(pageNumber, pageSize, cancellationToken);
    }

    public async Task<PermissionDto?> GetOnePermissionService(int id, CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetOnePermissionByIdRepository(id, cancellationToken);
    }

    public async Task<PermissionDto> UpdatePermissionService(PermissionDto request, CancellationToken cancellationToken)
    {
        var permission = await _permissionRepository
            .GetOnePermissionByIdForUpdateRepository(
                request.PermissionId, cancellationToken);

        if (permission is null)
            throw new BadRequestException("Permission data not found.");

        permission.PermissionCode = request.PermissionCode;
        permission.Modified = DateTime.UtcNow;
        permission.ModifiedBy = GetClaimFor.GetUsername(_httpContextAccessor);

        await _permissionRepository
            .UpdatePermissionRepository(permission, cancellationToken);

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
}
