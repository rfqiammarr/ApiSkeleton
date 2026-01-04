using ApiSkeleton.Application.Common.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.ApiSkeleton.Api.Areas.V1.Controllers;
using RifqiAmmarR.ApiSkeleton.Application.Common.Extensions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Role.GetManyRoles;
using RifqiAmmarR.ApiSKeleton.Api.Contracts.Roles.Queries;

namespace RifqiAmmarR.ApiSKeleton.Api.Areas.V1.Controllers.Masters;

public class RoleController(IGetManyRolesQuery _getManyRoles) : ApiControllerBase
{
    [Authorize]
    [HttpGet]
    [Produces(typeof(ListResponse<GetRoleResponse>))]
    public async Task<ActionResult<ListResponse<GetRoleResponse>>> GetManyRoles(CancellationToken cancellationToken)
    {
        var roles = await _getManyRoles.ExecuteAsync(cancellationToken);

        var response = roles.Select(role => new GetRoleResponse
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
        })
        .ToList()
        .ToListResponse();

        return Ok(response);
    }
}
