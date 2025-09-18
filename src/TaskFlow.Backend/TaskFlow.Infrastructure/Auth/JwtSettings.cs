namespace TaskFlow.Infrastructure.Auth;

public class JwtSettings
{
    public string Key { get; set; } = string.Empty;      // chave secreta
    public string Issuer { get; set; } = string.Empty;   // emissor
    public string Audience { get; set; } = string.Empty; // público
    public int ExpirationMinutes { get; set; } = 60;     // duração do token
}