using TaskFlow.Application.DTOs.Auth;

namespace TaskFlow.Application.Interfaces.Services;

public interface IAuthServices
{
    Task<LoginResponseDto?> LoginAsync(LoginDto dto);
}