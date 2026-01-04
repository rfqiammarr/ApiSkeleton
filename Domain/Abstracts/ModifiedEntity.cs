using RifqiAmmarR.ApiSkeleton.Domain.Interfaces;

namespace RifqiAmmarR.ApiSkeleton.Domain.Abstracts;

public abstract class ModifiedEntity : Entity, IDeletable, IUpdatable
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? Modified { get; set; }
    public string? ModifiedBy { get; set; }
}
