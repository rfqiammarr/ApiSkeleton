using ApiSkeleton.Application.Common.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.ApiSkeleton.Api.Areas.V1.Controllers;
using RifqiAmmarR.ApiSkeleton.Application.Common.Constans;
using RifqiAmmarR.ApiSkeleton.Application.Common.Extensions;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Roles;
using RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Constants;
using RifqiAmmarR.ApiSKeleton.Api.Contracts.Roles.Commands;
using RifqiAmmarR.ApiSKeleton.Api.Contracts.Roles.Queries;

namespace RifqiAmmarR.ApiSKeleton.Api.Areas.V1.Controllers.Masters;

[Authorize(Policy = ApiEndPoint.AuthorizePolicy)]
public class RoleController(IRoleService _getManyRoles) : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetRoleResponse>))]
    public async Task<ActionResult<ListResponse<GetRoleResponse>>> GetManyRoles(CancellationToken cancellationToken)
    {
        var roles = await _getManyRoles.GetManyRolesService(cancellationToken);

        var response = roles.Select(role => new GetRoleResponse
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
        })
        .ToList()
        .ToListResponse();

        return Ok(response);
    }

    [HttpGet(ApiEndPoint.V1.RouteTemplateFor.Masters.Roles.RoleId)]
    [Produces(typeof(GetRoleResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetRoleResponse>> GetOneRole([FromRoute] GetRoleRequest query, CancellationToken cancellationToken)
    {
        var roleDto = await _getManyRoles.GetOneRoleService(new()
        {
            RoleId = query.RoleId
        }, cancellationToken);

        var response = new GetRoleResponse
        {
            RoleId = roleDto.RoleId,
            RoleName = roleDto.RoleName,
        };

        return Ok(response);
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [Produces(typeof(GetRoleResponse))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<GetRoleResponse>> CreateRole([FromBody] RoleRequest request, CancellationToken cancellationToken)
    {
        var roleDto = await _getManyRoles.CreateRoleService(new()
        {
            RoleName = request.RoleName,
        }, cancellationToken);

        var response = new GetRoleResponse
        {
            RoleId = roleDto.RoleId,
            RoleName = roleDto.RoleName,
        };

        return CreatedAtAction(nameof(GetOneRole), new { roleId = response.RoleId }, response);
    }

    [HttpPut(ApiEndPoint.V1.RouteTemplateFor.Masters.Roles.RoleId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> UpdateRole([FromRoute] int RoleId, [FromBody] RoleRequest request, CancellationToken cancellationToken)
    {
        await _getManyRoles.UpdateRoleService(new()
        {
            RoleId = RoleId,
            RoleName = request.RoleName,
        }, cancellationToken);
        return NoContent();
    }

    [HttpDelete(ApiEndPoint.V1.RouteTemplateFor.Masters.Roles.RoleId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRole([FromRoute] int RoleId, CancellationToken cancellationToken)
    {
        await _getManyRoles.DeleteRoleService(new()
        {
            RoleId = RoleId,
        }, cancellationToken);
        return NoContent();
    }
}
