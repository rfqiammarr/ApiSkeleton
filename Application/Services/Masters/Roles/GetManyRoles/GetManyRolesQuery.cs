using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Role.GetManyRolesRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Role.GetManyRoles;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Roles.GetManyRoles;

public class GetManyRolesQuery(IGetManyRolesRepository _getManyRolesRepository) : IGetManyRolesQuery
{
    public async Task<IEnumerable<RoleDto>> ExecuteAsync(CancellationToken cancellationToken)
    {
        return await _getManyRolesRepository.ExecuteAsync(cancellationToken);
    }
}
