using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.Login;

public interface ILoginAsync
{
    Task LoginAsync(UserDto request);
}
