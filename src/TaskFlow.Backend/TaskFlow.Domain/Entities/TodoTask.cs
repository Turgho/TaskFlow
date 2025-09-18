using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class TodoTask : BaseEntity
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public TodoTaskCategory Category { get; set; } = TodoTaskCategory.Personal;
    public TodoTaskPriority Priority { get; set; } = TodoTaskPriority.Low;
    public TodoTaskStatus Status { get; set; } = TodoTaskStatus.Pending;
    
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DoneAt { get; set; }
}