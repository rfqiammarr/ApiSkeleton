using RifqiAmmarR.ApiSkeleton.Application.Common.Responses;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Permissions;

public interface IPermissionService
{
    public Task<PaginatedListResponse<PermissionDto>> GetPermissionsService(int pageNumber, int pageSize, CancellationToken cancellationToken);
    public Task<PermissionDto?> GetOnePermissionService(int id, CancellationToken cancellationToken);
    public Task<PermissionDto> CreatePermissionService(PermissionDto request, CancellationToken cancellationToken);
    public Task<PermissionDto> UpdatePermissionService(PermissionDto request, CancellationToken cancellationToken);
    public Task DeletePermissionService(int id, CancellationToken cancellationToken);
}
