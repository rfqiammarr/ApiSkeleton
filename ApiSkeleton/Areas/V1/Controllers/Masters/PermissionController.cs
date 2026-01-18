using ApiSkeleton.Application.Common.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.ApiSkeleton.Api.Areas.V1.Controllers;
using RifqiAmmarR.ApiSkeleton.Application.Common.Constans;
using RifqiAmmarR.ApiSkeleton.Application.Common.Responses;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Masters.Permissions;
using RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Constants;
using RifqiAmmarR.ApiSKeleton.Api.Contracts.Global.Queries;
using RifqiAmmarR.ApiSKeleton.Api.Contracts.Permissions.Commands;
using RifqiAmmarR.ApiSKeleton.Api.Contracts.Permissions.Queries;

namespace RifqiAmmarR.ApiSKeleton.Api.Areas.V1.Controllers.Masters;

[Authorize(Policy = ApiEndPoint.RequireManager)]
public sealed class PermissionController(IPermissionService _service) : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(ListResponse<GetPermissionResponse>))]
    public async Task<ActionResult<PaginatedListResponse<GetPermissionResponse>>> GetManyPermissions([FromQuery] PaginateRequest paginateRequest, CancellationToken cancellationToken)
    {
        var response = await _service.GetPermissionsService(paginateRequest.PageNumber,paginateRequest.PageSize, cancellationToken);
        return Ok(response);
    }

    [HttpGet(ApiEndPoint.V1.RouteTemplateFor.Masters.Permissions.PermissionId)]
    [Produces(typeof(GetPermissionResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetPermissionResponse>> GetOnePermission([FromRoute] int permissionId, CancellationToken cancellationToken)
    {
        var response = await _service.GetOnePermissionService(permissionId, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [Consumes(ContentTypes.ApplicationJson)]
    [Produces(typeof(GetPermissionResponse))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<GetPermissionResponse>> CreatePermission([FromBody] PermissionRequest request, CancellationToken cancellationToken)
    {
        var permissionData = await _service.CreatePermissionService(new()
        {
            PermissionCode = request.PermissionCode,
        }, cancellationToken);

        var response = new GetPermissionResponse
        {
            PermissionId = permissionData.PermissionId,
            PermissionCode = permissionData.PermissionCode,
        };

        return CreatedAtAction(nameof(CreatePermission), response);
    }

    [HttpPut(ApiEndPoint.V1.RouteTemplateFor.Masters.Permissions.PermissionId)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> UpdatePermission([FromRoute] int permissionId, [FromBody] PermissionRequest request, CancellationToken cancellationToken)
    {
        await _service.UpdatePermissionService(new()
        {
            PermissionId = permissionId,
            PermissionCode = request.PermissionCode,
        }, cancellationToken);
        return NoContent();
    }

    [HttpDelete(ApiEndPoint.V1.RouteTemplateFor.Masters.Permissions.PermissionId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePermission([FromRoute] int PermissionId, CancellationToken cancellationToken)
    {
        await _service.DeletePermissionService(PermissionId, cancellationToken);
        return NoContent();
    }
}
