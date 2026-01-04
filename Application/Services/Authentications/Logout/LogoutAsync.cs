using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.LogoutRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Logout;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Logout;

public class LogoutAsync(ILogoutRepository _logoutRepository) : ILogoutAsync
{
    public async Task Handle(CancellationToken cancellationToken)
    {
        await _logoutRepository.Handle(cancellationToken);
    }
}
