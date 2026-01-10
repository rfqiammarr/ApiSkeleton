using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Permissions;

public interface IPermissionService
{
    public Task<IEnumerable<PermissionDto>> GetManyPermissionsService(CancellationToken cancellationToken);
    public Task<PermissionDto> GetOnePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken);
    public Task<PermissionDto> CreatePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken);
    public Task<PermissionDto> UpdatePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken);
    public Task DeletePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken);
}
