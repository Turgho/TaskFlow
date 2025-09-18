using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.DTOs.TodoTasks;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;
using TaskFlow.Domain.Interfaces;

namespace TaskFlow.Application.Services;


public class TodoTaskServices(IUnitOfWork unitOfWork, IMapper mapper) : ITodoTaskServices
{
    public async Task<IEnumerable<TodoTaskResponseDto>> GetAllAsync(Guid userId)
    {
        var tasks = await unitOfWork.Repository<TodoTask>()
            .Query()
            .Where(t => t.UserId == userId)
            .ToListAsync();

        return mapper.Map<IEnumerable<TodoTaskResponseDto>>(tasks);
    }

    public async Task<TodoTaskResponseDto?> GetByIdAsync(Guid id)
    {
        var task = await unitOfWork.Repository<TodoTask>().GetByIdAsync(id);
        return task is null ? null : mapper.Map<TodoTaskResponseDto>(task);
    }

    public async Task<TodoTaskResponseDto> CreateAsync(Guid userId, CreateTodoTaskDto dto)
    {
        var task = mapper.Map<TodoTask>(dto);

        await unitOfWork.Repository<TodoTask>().AddAsync(task);
        await unitOfWork.CommitAsync();

        return mapper.Map<TodoTaskResponseDto>(task);
    }

    public async Task<TodoTaskResponseDto> UpdateAsync(Guid id, UpdateTodoTaskDto dto)
    {
        var task = await unitOfWork.Repository<TodoTask>().GetByIdAsync(id);
        if (task == null)
            throw new Exception("Task não encontrada.");

        // Atualiza campos do DTO (somente se vierem preenchidos)
        if (!string.IsNullOrEmpty(dto.Title)) task.Title = dto.Title;
        if (dto.Description != null) task.Description = dto.Description;
        if (dto.Category.HasValue) task.Category = dto.Category.Value;
        if (dto.Priority.HasValue) task.Priority = dto.Priority.Value;
        if (dto.Status.HasValue)
        {
            task.Status = dto.Status.Value;
            if (task.Status == TodoTaskStatus.Done)
                task.DoneAt = DateTime.UtcNow;
        }

        task.UpdatedAt = DateTime.UtcNow;

        unitOfWork.Repository<TodoTask>().Update(task);
        await unitOfWork.CommitAsync();

        return mapper.Map<TodoTaskResponseDto>(task);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var task = await unitOfWork.Repository<TodoTask>().GetByIdAsync(id);
        if (task == null) return false;

        unitOfWork.Repository<TodoTask>().Remove(task);
        await unitOfWork.CommitAsync();
        return true;
    }
}