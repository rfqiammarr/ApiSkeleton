namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Repositories.Users.RefreshTokenRepository;

public interface IGetRefreshTokenRepository
{
    public Task Handle(CancellationToken cancellationToken);
}
