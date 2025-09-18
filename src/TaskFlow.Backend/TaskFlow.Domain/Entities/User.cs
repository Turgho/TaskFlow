using TaskFlow.Domain.ValueObjects.User;

namespace TaskFlow.Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required Email Email { get; init; }
    public required PasswordHash PasswordHash { get; set; }
    
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }
}