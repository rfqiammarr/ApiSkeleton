using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Permissions;

public interface IPermissionRepository
{
    Task<IEnumerable<PermissionDto>> GetManyPermissionsRepositories(CancellationToken cancellationToken);
    Task<PermissionDto> GetOnePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken);
    Task<PermissionDto> CreatePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken);
    Task<PermissionDto> UpdatePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken);
    Task DeletePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken);
}
