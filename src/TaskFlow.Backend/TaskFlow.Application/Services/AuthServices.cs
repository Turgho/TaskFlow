using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.DTOs.Auth;
using TaskFlow.Application.DTOs.Users;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Services;

public class AuthServices(IUnitOfWork unitOfWork, IMapper mapper, IJwtServices jwtServices) : IAuthServices
{
    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
        var user = await unitOfWork.Repository<User>()
            .Query()
            .FirstOrDefaultAsync(u => u.Email.Value == dto.Email);

        if (user is null || !user.PasswordHash.Verify(dto.Password))
            return null;

        // Gerar token
        var token = jwtServices.GenerateToken(user);

        // Mapper apenas para User -> UserResponseDto
        var userDto = mapper.Map<UserResponseDto>(user);

        // Mapear o User e criar o LoginResponseDto com token
        return new LoginResponseDto(
            Token: token.Token,
            ExpiresAt: token.ExpiresAt,
            User: userDto
        );
    }
}