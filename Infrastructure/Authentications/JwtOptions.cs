namespace RifqiAmmarR.ApiSKeleton.Infrastructure.Authentications;

public class JwtOptions
{
    public string Key { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public int ExpiresMinutes { get; set; } = default!;
    public int AccessTokenMinutes { get; set; } = default!;
    public double RefreshTokenDays { get; set; } = default!;
}
