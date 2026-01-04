using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.ApiSkeleton.Api.Contracts.Auth.Login;
using RifqiAmmarR.ApiSkeleton.Api.Contracts.Auth.Register;
using RifqiAmmarR.ApiSkeleton.Application.Common.Constans;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.Login;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.Logout;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.RefreshToken;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.Register;
using RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Constants;
using System.Security.Claims;

namespace RifqiAmmarR.ApiSkeleton.Api.Areas.V1.Controllers.Authentication;

public class AuthenticationController : ApiControllerBase
{
   private readonly IRegisterAsync _userRegisterService;
   private readonly ILoginAsync _loginAsync;
   private readonly IGetRefreshToken _refreshToken;
   private readonly ILogoutAsync _logoutAsync;

    public AuthenticationController(IRegisterAsync userRegisterService, ILoginAsync loginAsync, IGetRefreshToken getRefreshToken, ILogoutAsync logoutAsync)
    {
        _userRegisterService = userRegisterService;
        _loginAsync = loginAsync;
        _refreshToken = getRefreshToken;
        _logoutAsync = logoutAsync;
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

        return CreatedAtAction(nameof(Register), result.Username);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest command)
    {
        try
        {
            UserDto request = new UserDto
            {
                Username = command.Username,
                Email = command.Email,
                Password = command.Password
            };

            await _loginAsync.LoginAsync(request);

            return Ok();
        }
        catch (Exception ex)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Unauthorized(new { message = ex.Message });
        }
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userName = User.FindFirstValue(ClaimTypes.Name);
        var email = User.FindFirstValue(ClaimTypes.Email);
        var role = User.FindFirstValue(ClaimTypes.Role);

        return Ok(new { userId, role, email, userName });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(CancellationToken cancellationToken)
    {
        await _refreshToken.Handle(cancellationToken);
        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _logoutAsync.Handle();
        return Ok();
    }

}
