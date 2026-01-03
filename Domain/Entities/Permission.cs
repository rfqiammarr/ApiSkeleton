using Domain.Abstracts;

namespace Domain.Entities;

public class Permission : ModifiedEntity
{
    public string PermissionCode { get; set; } = default!;
    public ICollection<User> Users { get; set; } = new List<User>();
}
