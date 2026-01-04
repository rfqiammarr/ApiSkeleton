namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.User.RefreshToken;

public interface IGetRefreshToken
{
    public Task Handle(CancellationToken cancellationToken);
}
