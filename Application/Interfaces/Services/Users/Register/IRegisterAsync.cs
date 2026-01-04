using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Register;

public interface IRegisterAsync
{
    Task<UserDto> RegisterAsync(UserDto userDto, CancellationToken cancellationToken = default);
}
