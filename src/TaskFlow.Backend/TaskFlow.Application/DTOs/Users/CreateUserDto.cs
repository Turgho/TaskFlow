namespace TaskFlow.Application.DTOs.Users;

public record CreateUserDto(
    string Username,
    string Email,
    string Password
);