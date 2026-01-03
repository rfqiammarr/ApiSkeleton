using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentications;

public class AuthService : IAuthService
{
    private readonly JwtOptions _jwtOptions;

    public AuthService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string GenerateJwtToken(UserDto userDto)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, userDto.UserId.ToString()),
        new Claim(ClaimTypes.Name, userDto.Username),
        new Claim(ClaimTypes.Role, userDto.RoleName)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtOptions.Key)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiresMinutes = _jwtOptions.ExpiresMinutes ?? 60;

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
