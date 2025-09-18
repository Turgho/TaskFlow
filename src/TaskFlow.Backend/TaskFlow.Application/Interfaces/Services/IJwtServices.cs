using TaskFlow.Application.DTOs.Auth;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Services;

public interface IJwtServices
{
    JwtToken GenerateToken(User user);
}