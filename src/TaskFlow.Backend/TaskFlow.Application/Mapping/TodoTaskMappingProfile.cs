using AutoMapper;
using TaskFlow.Application.DTOs.TodoTasks;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Mapping;

public class TodoTaskMappingProfile : Profile
{
    public TodoTaskMappingProfile()
    {
        // Entity -> Response DTO
        CreateMap<TodoTask, TodoTaskResponseDto>();

        // Create DTO -> Entity
        CreateMap<CreateTodoTaskDto, TodoTask>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.DoneAt, opt => opt.Ignore());

        // Update DTO -> Entity
        CreateMap<UpdateTodoTaskDto, TodoTask>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}