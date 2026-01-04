using RifqiAmmarR.ApiSkeleton.Domain.Abstracts;

namespace RifqiAmmarR.ApiSkeleton.Domain.Entities;

public class User 
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool IsActive { get; set; } = false;
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? Modified { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public RefreshToken? RefreshToken { get; set; }

    public Role Role { get; set; } = default!;
    public Permission Permission { get; set; } = default!;
}
