namespace TaskFlow.Application.DTOs.Users;

public record UpdateUserDto(
    string Username,
    string? Password
);