using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RefreshTokenRepository;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.RefreshToken;

namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.GetRefreshToken;

public class GetRefreshTokenService(IRefreshTokenRepository getRefreshToken) : IGetRefreshToken
{
    public async Task Handle(CancellationToken cancellationToken)
    {
        await getRefreshToken.GetRefreshToken(cancellationToken);
    }
}
