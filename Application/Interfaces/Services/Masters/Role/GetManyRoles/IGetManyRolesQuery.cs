using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Role.GetManyRoles;

public interface IGetManyRolesQuery
{
    public Task<IEnumerable<RoleDto>> ExecuteAsync(CancellationToken cancellationToken);
}
