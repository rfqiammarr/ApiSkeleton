namespace RifqiAmmarR.ApiSkeleton.Application.DTOs.Roles;

public class RoleDto
{
    public int? RoleId { get; set; }
    public string RoleName { get; set; } = default!;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = default!;
    public bool? IsDeleted { get; set; }
    public DateTime? Modified { get; set; }
    public string? ModifiedBy { get; set; } = default!;
}
