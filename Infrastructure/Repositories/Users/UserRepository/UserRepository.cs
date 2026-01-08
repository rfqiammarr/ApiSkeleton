using Microsoft.EntityFrameworkCore;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.UserRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Persistences;

namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Repositories.Users.UserRepository;

public class UserRepository(IAppDbContext _context) : IUserRepository
{
    public async Task<bool> IsUsernameOrEmailHasAlreadyExist(string? userName, string? email, CancellationToken cancellationToken = default)
    {
       return await _context.Users.AsNoTracking().AnyAsync(
        u => u.Username == userName || u.Email == email,
        cancellationToken);
    }
}
