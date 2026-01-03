using Domain.Abstracts;

namespace Domain.Entities;

public class Role : ModifiedEntity
{
    public string RoleName { get; set; } = default!;

    public ICollection<User> Users { get; set; } = new List<User>();
}
