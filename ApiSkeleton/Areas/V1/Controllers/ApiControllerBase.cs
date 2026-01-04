
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace RifqiAmmarR.ApiSkeleton.Api.Areas.V1.Controllers;

[Route(ApiVersioning.V1.BaseRoute)]
[ApiVersion(ApiVersioning.V1.Number)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
}

