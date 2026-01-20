using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Roles;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Roles;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Roles;

public sealed class RoleService(IRolesRepository _roleRepository) : IRoleService
{
    public async Task<RoleDto> CreateRoleService(RoleDto roleDto, CancellationToken cancellationToken)
    {
        return await _roleRepository.CreateRoleRepository(roleDto, cancellationToken);
    }

    public async Task DeleteRoleService(RoleDto roleDto, CancellationToken cancellationToken)
    {
        await _roleRepository.DeleteRoleRepository(roleDto, cancellationToken);
    }

    public async Task<IEnumerable<RoleDto>> GetManyRolesService(CancellationToken cancellationToken)
    {
        return await _roleRepository.GetManyRolesRepository(cancellationToken);
    }

    public async Task<RoleDto> GetOneRoleService(int id, CancellationToken cancellationToken)
    {
        var data = await _roleRepository.GetOneRoleByIdRepository(id, cancellationToken);

        return new RoleDto
        {
            RoleId = data!.RoleId,
            RoleName = data.RoleName,
            CreatedAt = data.CreatedAt,
            CreatedBy = data.CreatedBy,
            IsDeleted = data.IsDeleted,
            Modified = data.Modified,
            ModifiedBy = data.ModifiedBy
        };
    }

    public async Task<RoleDto> UpdateRoleService(RoleDto roleDto, CancellationToken cancellationToken)
    {
        return await _roleRepository.UpdateRoleRepository(roleDto, cancellationToken);
    }
}