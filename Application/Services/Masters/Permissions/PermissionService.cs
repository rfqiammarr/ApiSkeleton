using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Permissions;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Permissions;

public sealed class PermissionService : IPermissionService
{
    public Task<PermissionDto> CreatePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeletePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PermissionDto>> GetManyPermissionsService(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PermissionDto> GetOnePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PermissionDto> UpdatePermissionService(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
