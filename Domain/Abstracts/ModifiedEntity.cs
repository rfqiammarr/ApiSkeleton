using RifqiAmmarR.FinanTrackr.Domain.Interfaces;

namespace Domain.Abstracts;

public abstract class ModifiedEntity : Entity, IDeletable, IUpdatable
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? Modified { get; set; }
    public string? ModifiedBy { get; set; }
}
