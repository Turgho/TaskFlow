namespace TaskFlow.Application.DTOs.Users;

public record UserResponseDto(
    Guid Id,
    string Username,
    string Email,
    DateTime CreatedAt,
    DateTime? LastLoginAt
);