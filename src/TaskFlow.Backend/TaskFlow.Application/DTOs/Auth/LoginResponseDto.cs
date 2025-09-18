using TaskFlow.Application.DTOs.Users;

namespace TaskFlow.Application.DTOs.Auth;

public record LoginResponseDto(
    string Token,
    DateTime ExpiresAt,
    UserResponseDto User
);