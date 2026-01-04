namespace RifqiAmmarR.ApiSkeleton.Domain.Interfaces;

public interface IUpdatable
{
    public DateTime? Modified { get; set; }
    public string? ModifiedBy { get; set; }
}
