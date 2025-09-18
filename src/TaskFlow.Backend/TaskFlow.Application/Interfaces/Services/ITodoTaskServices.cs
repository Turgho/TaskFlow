using TaskFlow.Application.DTOs.TodoTasks;

namespace TaskFlow.Application.Interfaces.Services;

public interface ITodoTaskServices
{
    // Retorna todas as tasks de um usuário
    Task<IEnumerable<TodoTaskResponseDto>> GetAllAsync(Guid userId);

    // Retorna uma task específica
    Task<TodoTaskResponseDto?> GetByIdAsync(Guid id);

    // Cria uma task a partir do DTO
    Task<TodoTaskResponseDto> CreateAsync(Guid userId, CreateTodoTaskDto dto);

    // Atualiza uma task existente
    Task<TodoTaskResponseDto> UpdateAsync(Guid id, UpdateTodoTaskDto dto);

    // Deleta uma task pelo Id
    Task<bool> DeleteAsync(Guid id);
}