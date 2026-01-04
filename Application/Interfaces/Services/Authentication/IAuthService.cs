using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;

public interface IAuthService
{
    public string GenerateJwtToken(UserDto userDto);
    public string GenerateRefreshToken();
    public void SetAccessTokenCookie(string token);
    public void SetRefreshTokenCookie(string refreshToken);
    public Task<UserDto> AuthenticateAsync(UserDto userDto);

}
