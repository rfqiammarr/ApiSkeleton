using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Authentication;
using RifqiAmmarR.ApiSkeleton.Application.Interfaces.Services.Security;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Authentications;
using RifqiAmmarR.ApiSKeleton.Infrastructure.Persistences.DataContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RifqiAmmarR.ApiSkeleton.Infrastructure.Authentications;

public class AuthService : IAuthService
{
    private readonly JwtOptions _jwtOptions;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAppDbContext _context;
    private readonly IPasswordHasher _hasher;

    public AuthService(IOptions<JwtOptions> jwtOptions, IHttpContextAccessor httpContextAccessor, IAppDbContext context, IPasswordHasher hasher)
    {
        _jwtOptions = jwtOptions.Value;
        _httpContextAccessor = httpContextAccessor;
        _context = context;
        _hasher = hasher;
    }

    public async Task<UserDto> AuthenticateAsync(UserDto userDto)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .Include(u => u.Permission)
            .SingleOrDefaultAsync(x => x.Email == userDto.Email || x.Username == userDto.Username);

        if (user is null) return null;
        if (!user.IsActive) return null;

        var valid = _hasher.Verify(user.PasswordHash, userDto.Password);
        if (!valid) return null;

        return new UserDto 
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            RoleName = user.Role.RoleName,
            PermissionCode = user.Permission.PermissionCode
        };
    }

    public string GenerateJwtToken(UserDto userDto)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, userDto.UserId.ToString()),
        new Claim(ClaimTypes.Name, userDto.Username),
        new Claim(ClaimTypes.Email, userDto.Email),
        new Claim(ClaimTypes.Role, userDto.RoleName)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtOptions.Key)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiresMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomBytes = RandomNumberGenerator.GetBytes(64);
        return Convert.ToBase64String(randomBytes);
    }

    public void SetAccessTokenCookie(string token)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Append(
            "access_token",
            token,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddMinutes(
                    _jwtOptions.AccessTokenMinutes)
            });
    }

    public void SetRefreshTokenCookie(string token)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Append(
            "refresh_token",
            token,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(
                    _jwtOptions.RefreshTokenDays)
            });
    }

}
