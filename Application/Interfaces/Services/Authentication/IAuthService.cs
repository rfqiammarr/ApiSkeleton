using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;

public interface IAuthService
{
    public string GenerateJwtToken(UserDto userDto);
}
