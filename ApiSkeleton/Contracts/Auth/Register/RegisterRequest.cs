namespace RifqiAmmarR.ApiSkeleton.Api.Contracts.Auth.Register;

public class RegisterRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = default!;
}
