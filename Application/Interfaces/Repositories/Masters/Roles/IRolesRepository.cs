using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Roles;

public interface IRolesRepository
{
    Task<IEnumerable<RoleDto>> GetManyRolesRepository(CancellationToken cancellationToken);
    Task<RoleDto> GetOneRoleRepository(RoleDto roleDto, CancellationToken cancellationToken);
    Task<RoleDto> CreateRoleRepository(RoleDto roleDto, CancellationToken cancellationToken);
    Task<RoleDto> UpdateRoleRepository(RoleDto roleDto, CancellationToken cancellationToken);
    Task DeleteRoleRepository(RoleDto roleDto, CancellationToken cancellationToken);
}