namespace TaskFlow.Application.DTOs.Auth;

public record JwtToken(string Token, DateTime ExpiresAt);