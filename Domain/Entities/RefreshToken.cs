using RifqiAmmarR.ApiSkeleton.Domain.Abstracts;

namespace RifqiAmmarR.ApiSkeleton.Domain.Entities;

public class RefreshToken : Entity
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; }
    public User User { get; set; } = default!;
}