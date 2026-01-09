using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Roles;

public interface IRoleService
{
    public Task<IEnumerable<RoleDto>> GetManyRolesService(CancellationToken cancellationToken);
    public Task<RoleDto> GetOneRoleService(RoleDto roleDto, CancellationToken cancellationToken);
    public Task<RoleDto> CreateRoleService(RoleDto roleDto, CancellationToken cancellationToken);
    public Task<RoleDto> UpdateRoleService(RoleDto roleDto, CancellationToken cancellationToken);
    public Task DeleteRoleService(RoleDto roleDto, CancellationToken cancellationToken);
}