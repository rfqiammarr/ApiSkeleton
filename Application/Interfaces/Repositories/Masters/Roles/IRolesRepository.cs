using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Roles;

public interface IRolesRepository
{
    Task<IEnumerable<RoleDto>> GetManyRolesRepository(CancellationToken cancellationToken);
    Task<Role> GetOneRoleByIdRepository(int id, CancellationToken cancellationToken);
    Task<RoleDto> CreateRoleRepository(RoleDto roleDto, CancellationToken cancellationToken);
    Task<RoleDto> UpdateRoleRepository(RoleDto roleDto, CancellationToken cancellationToken);
    Task DeleteRoleRepository(RoleDto roleDto, CancellationToken cancellationToken);
}