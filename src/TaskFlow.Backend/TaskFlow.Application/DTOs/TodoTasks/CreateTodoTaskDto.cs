using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.DTOs.TodoTasks;

public record CreateTodoTaskDto(
    string Title,
    string? Description,
    TodoTaskCategory Category,
    TodoTaskPriority Priority
);