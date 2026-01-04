namespace RifqiAmmarR.ApiSkeleton.Api.Contracts.Auth.Login;

public sealed record LoginRequest
{
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
