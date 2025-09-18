using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.DTOs.Users;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Domain.ValueObjects.User;

namespace TaskFlow.Application.Services;

public class UserServices(IUnitOfWork unitOfWork, IMapper mapper) : IUserServices
{
    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        var users = await unitOfWork.Repository<User>().GetAllAsync();
        return mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public async Task<UserResponseDto?> GetByIdAsync(Guid id)
    {
        var user = await unitOfWork.Repository<User>().GetByIdAsync(id);
        return user is null ? null : mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        // Verifica se já existe usuário com o mesmo email
        var existingUser = await unitOfWork.Repository<User>()
            .Query()
            .FirstOrDefaultAsync(u => u.Email.Value == dto.Email);

        if (existingUser != null)
            throw new Exception("Email já está em uso.");

        // Cria a entidade
        var user = mapper.Map<User>(dto);

        await unitOfWork.Repository<User>().AddAsync(user);
        await unitOfWork.CommitAsync(); // Salva as mudanças no banco

        return mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserResponseDto> UpdateAsync(Guid id, UpdateUserDto dto)
    {
        var user = await unitOfWork.Repository<User>().GetByIdAsync(id);
        if (user == null)
            throw new Exception("Usuário não encontrado.");

        mapper.Map(dto, user); // Aplica alterações do DTO na entidade

        // Se senha foi informada, atualiza o hash
        if (!string.IsNullOrEmpty(dto.Password))
            user.PasswordHash = new PasswordHash(dto.Password);

        unitOfWork.Repository<User>().Update(user);
        await unitOfWork.CommitAsync();

        return mapper.Map<UserResponseDto>(user);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await unitOfWork.Repository<User>().GetByIdAsync(id);
        if (user == null)
            return false;

        unitOfWork.Repository<User>().Remove(user);
        await unitOfWork.CommitAsync();
        
        return true;
    }
}