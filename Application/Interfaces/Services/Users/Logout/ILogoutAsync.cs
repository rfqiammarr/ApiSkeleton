namespace RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Users.Logout;

public interface ILogoutAsync
{
    Task Handle(CancellationToken cancellationToken);
}
