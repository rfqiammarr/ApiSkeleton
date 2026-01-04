using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RefreshTokenRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.RefreshToken;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.GetRefreshToken;

public class GetRefreshTokenService(IGetRefreshTokenRepository getRefreshToken) : IGetRefreshToken
{
    public async Task Handle(CancellationToken cancellationToken)
    {
        await getRefreshToken.Handle(cancellationToken);
    }
}
