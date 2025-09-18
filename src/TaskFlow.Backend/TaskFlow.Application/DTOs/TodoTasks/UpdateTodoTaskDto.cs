using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.DTOs.TodoTasks;

public record UpdateTodoTaskDto(
    string? Title,
    string? Description,
    TodoTaskCategory? Category,
    TodoTaskPriority? Priority,
    TodoTaskStatus? Status
);