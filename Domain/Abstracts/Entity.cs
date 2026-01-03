using Domain.Interfaces;

namespace Domain.Abstracts;

public abstract class Entity : ICreatable
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = default!;
}
