using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LoginRepository;

public interface IGetLoginRepository
{
    Task GetLoginAsync(UserDto request, CancellationToken cancellationToken = default);
}
