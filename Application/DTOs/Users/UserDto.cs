namespace RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;
    public int? RoleId { get; set; } = default!;
    public string RoleName { get; set; } = default!;
    public int? PermissionId { get; set; } = default!;
    public string? PermissionCode { get; set; } = default!;
}
