using AutoMapper;
using TaskFlow.Application.DTOs.Users;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.ValueObjects.User;

namespace TaskFlow.Application.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        // Entity -> Response DTO
        CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

        // Create DTO -> Entity
        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
            .ForMember(dest => dest.PasswordHash, opt=> opt.MapFrom(src => PasswordHash.FromPlainText(src.Password)))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastLoginAt, opt => opt.Ignore());

        // Update DTO -> Entity
        CreateMap<UpdateUserDto, User>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}