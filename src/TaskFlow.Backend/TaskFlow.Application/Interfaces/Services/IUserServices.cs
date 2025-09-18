using TaskFlow.Application.DTOs.Users;

namespace TaskFlow.Application.Interfaces.Services;

public interface IUserServices
{
    // Retorna todos os usuários
    Task<IEnumerable<UserResponseDto>> GetAllAsync();

    // Retorna um usuário específico pelo Id
    Task<UserResponseDto?> GetByIdAsync(Guid id);

    // Cria um novo usuário
    Task<UserResponseDto> CreateAsync(CreateUserDto dto);

    // Atualiza um usuário existente
    Task<UserResponseDto> UpdateAsync(Guid id, UpdateUserDto dto);

    // Deleta um usuário pelo Id
    Task<bool> DeleteAsync(Guid id);
}