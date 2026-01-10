using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Permissions;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Masters.Permissions;

public sealed class PermissionRepository : IPermissionRepository
{
    public Task<PermissionDto> CreatePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeletePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PermissionDto>> GetManyPermissionsRepositories(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PermissionDto> GetOnePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PermissionDto> UpdatePermissionRepository(PermissionDto permissionDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
