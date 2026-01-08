using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Domain.Entities;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.UserRepository;

public interface IUserRepository
{
    public Task<bool> IsUsernameOrEmailHasAlreadyExist(string? userName, string? email, CancellationToken cancellationToken = default);
}
