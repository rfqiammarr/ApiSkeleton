using RifqiAmmarR.ApiSkeleton.Domain.Abstracts;

namespace RifqiAmmarR.ApiSkeleton.Domain.Entities;

public class User : ModifiedEntity
{
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool IsActive { get; set; } = false;
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    public RefreshToken? RefreshToken { get; set; }

    public Role Role { get; set; } = default!;
    public Permission Permission { get; set; } = default!;
}
