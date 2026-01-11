namespace RifqiAmmarR.ApiSkeleton.Domain.Entities;

public class Permission 
{
    public int PermissionId { get; set; }
    public string PermissionCode { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = default!;
    public bool IsDeleted { get; set; } = false;
    public DateTime? Modified { get; set; }
    public string? ModifiedBy { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
