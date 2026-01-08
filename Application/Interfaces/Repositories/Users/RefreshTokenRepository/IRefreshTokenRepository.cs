using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RefreshTokenRepository;

public interface IRefreshTokenRepository
{
    public Task GetRefreshToken(CancellationToken cancellationToken);
    public Task DeletedOldRefreshToken(CancellationToken cancellationToken);
    public Task SetRefreshToken(Guid userId, string newGenerateAccessToken, string newGenerateRefreshToken, CancellationToken cancellationToken);
}
