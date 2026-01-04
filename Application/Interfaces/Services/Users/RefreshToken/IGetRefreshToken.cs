namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.RefreshToken;

public interface IGetRefreshToken
{
    public Task Handle(CancellationToken cancellationToken);
}
