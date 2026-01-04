using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Masters.Role.GetManyRolesRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Masters.Roles.GetManyRolesRepository;

public class GetManyRolesRepository(IAppDbContext _context) : IGetManyRolesRepository
{
    public async Task<IEnumerable<RoleDto>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var data = await _context.Roles
            .AsNoTracking()
            .Where(x => x.IsDeleted != null )
            .Select(role => new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                CreatedAt = role.CreatedAt,
                CreatedBy = role.CreatedBy,
                IsDeleted = role.IsDeleted,
                Modified = role.Modified,
                ModifiedBy = role.ModifiedBy
            })
            .ToListAsync(cancellationToken);

        return data;
    }

}
