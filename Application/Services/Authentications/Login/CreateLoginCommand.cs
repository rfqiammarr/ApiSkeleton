using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RefreshTokenRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Login;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Login;

public class CreateLoginCommand(IRefreshTokenRepository _refreshTokenRepository, IAuthService _authService) : ILoginAsync
{
    public async Task Handle(UserDto request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _authService
            .AuthenticateAsync(request);

            if (user is null)
                throw new UnauthorizedAccessException("Invalid credentials");

            await _refreshTokenRepository.DeletedOldRefreshToken(cancellationToken);

            var newGenerateAccessToken = _authService.GenerateJwtToken(user);
            var newGenerateRefreshToken = _authService.GenerateRefreshToken();

            await _refreshTokenRepository.SetRefreshToken(user.UserId, newGenerateAccessToken, newGenerateRefreshToken, cancellationToken);
        }
        catch (Exception ex) 
        {
            var innerMessage = ex.InnerException?.Message;

            // log ke console / logger
            Console.WriteLine(innerMessage);

            throw new Exception(innerMessage ?? "Login failed", ex);
        }
    }
}
