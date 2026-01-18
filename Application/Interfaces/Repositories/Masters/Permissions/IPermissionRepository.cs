using RifqiAmmarR.ApiSkeleton.Application.Common.Responses;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Permissions;

public interface IPermissionRepository
{
    Task<PaginatedListResponse<PermissionDto>> GetManyPermissionsRepository(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<PermissionDto?> GetOnePermissionByIdRepository(int id, CancellationToken cancellationToken);
    Task CreatePermissionRepository(Permission entity, CancellationToken cancellationToken);
    Task UpdatePermissionRepository(Permission permission, CancellationToken cancellationToken);
    Task PermanentDeletePermissionRepository(Permission entityData, CancellationToken cancellationToken);
    Task<bool> IsPermissionDataExistRepository(string name, CancellationToken cancellationToken);
    Task<Permission?> GetOnePermissionByIdForUpdateRepository(int id, CancellationToken cancellationToken);
}
