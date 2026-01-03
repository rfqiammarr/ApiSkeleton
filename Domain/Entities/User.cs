using Domain.Abstracts;

namespace Domain.Entities;

public class User : ModifiedEntity
{
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool IsActive { get; set; } = false;
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }

    public RefreshToken? RefreshToken { get; set; }

    public Role Role { get; set; } = default!;
    public Permission Permission { get; set; } = default!;
}
