using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RegisterRepository;

public interface ICreateRegisterRepository
{
    Task<UserDto> Handle(UserDto request, string hasher, CancellationToken cancellationToken);
}
