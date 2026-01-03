namespace RifqiAmmarR.ApiSkeleton.Application.DTOs.Users;

public class UserDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Guid RoleId { get; set; } = default!;
    public string RoleName { get; set; } = default!;
    public Guid PermissionId { get; set; } = default!;
    public Guid PermissionCode { get; set; } = default!;
}
