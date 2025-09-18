using AutoMapper;
using TaskFlow.Application.DTOs.Auth;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Mapping;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        // Entity -> LoginResponse DTO
        CreateMap<User, LoginResponseDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Token, opt => opt.Ignore())       // Token será gerado no AuthService
            .ForMember(dest => dest.ExpiresAt, opt => opt.Ignore());
    }
}