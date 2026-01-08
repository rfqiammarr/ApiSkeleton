using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Login;

public interface ILoginAsync
{
    Task Handle(UserDto request, CancellationToken cancellationToken);
}
