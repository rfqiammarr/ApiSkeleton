using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Role.GetManyRolesRepository;

public interface IGetManyRolesRepository
{
    Task<IEnumerable<RoleDto>> ExecuteAsync(CancellationToken cancellationToken);
}
