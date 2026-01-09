namespace RifqiAmmarR.ApiSKeleton.Infrastructure.CORS;

public class CorsOptions
{
    public string PolicyName { get; set; } = default!;
    public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
}
