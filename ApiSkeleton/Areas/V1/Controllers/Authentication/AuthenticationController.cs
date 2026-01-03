using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.ApiSkeleton.Api.Contracts.Auth.Register;
using RifqiAmmarR.ApiSkeleton.Application.Common.Constans;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.Register;
using RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Constants;

namespace RifqiAmmarR.ApiSKeleton.Api.Areas.V1.Controllers.Authentication;

public class AuthenticationController : ApiControllerBase
{
   private readonly IRegisterAsync _userRegisterService;
    public AuthenticationController(IRegisterAsync userRegisterService)
    {
        _userRegisterService = userRegisterService;
    }

    [HttpPost(ApiEndPoint.V1.Authentications.RouteTemplateFor.Register)]
    [Consumes(ContentTypes.ApplicationJson)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register(
       RegisterRequest command,
       CancellationToken cancellationToken)
    {
        var request = new UserDto
        {
            Username = command.Username,
            Password = command.Password,
            Email = command.Email
        };

        var result = await _userRegisterService.RegisterAsync(request, cancellationToken);
        return CreatedAtAction(nameof(Register), result);
    }
}
