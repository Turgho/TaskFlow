using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.DTOs.TodoTasks;

public record TodoTaskResponseDto(
    Guid Id,
    string Title,
    string? Description,
    TodoTaskCategory Category,
    TodoTaskPriority Priority,
    TodoTaskStatus Status,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DoneAt
);