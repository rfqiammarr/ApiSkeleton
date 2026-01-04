using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LoginRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.Login;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Login;

public class CreateLoginCommand(IGetLoginRepository _getLoginRepository, IAuthService _authService) : ILoginAsync
{
    public async Task LoginAsync(UserDto request)
    {
        var user = await _authService
            .AuthenticateAsync(request);

        if (user is null)
            throw new UnauthorizedAccessException("Invalid credentials");

        await _getLoginRepository.GetLoginAsync(user);
    }
}
