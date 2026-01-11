using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Permissions;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Permissions;

public sealed class PermissionService(IPermissionRepository _permissionRepository) : IPermissionService
{
    public async Task<PermissionDto> CreatePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        return await _permissionRepository.CreatePermissionRepository(permissionDto, cancellationToken);
    }

    public async Task DeletePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
       await _permissionRepository.DeletePermissionRepository(permissionDto, cancellationToken);
    }

    public async Task<IEnumerable<PermissionDto>> GetManyPermissionsService(CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetManyPermissionsRepository(cancellationToken);
    }

    public async Task<PermissionDto> GetOnePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetOnePermissionRepository(permissionDto, cancellationToken);
    }

    public async Task<PermissionDto> UpdatePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        return await _permissionRepository.UpdatePermissionRepository(permissionDto, cancellationToken);
    }
}
