namespace RifqiAmmarR.ApiSkeleton.Application.DTOs.Permissions;

public class PermissionDto
{
    public int PermissionId { get; set; }
    public string PermissionCode { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public bool? IsDeleted { get; set; }
    public DateTime? Modified { get; set; }
    public string? ModifiedBy { get; set; } = string.Empty;
}
