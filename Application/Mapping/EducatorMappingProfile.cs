using Application.Dto;
using Application.Dto.Educator;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ValueObjects;

namespace Application.Mapping;

/// <summary>
/// Маппинг для преподавателЯ
/// </summary>
public class EducatorMappingProfile : Profile
{
    public EducatorMappingProfile()
    {
        CreateMap<Educator, EducatorGetByIdResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<Educator, EducatorGetAllResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
            
        CreateMap<Educator, EducatorCreateResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<Educator, EducatorUpdateResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<EducatorCreateRequest, Educator>()
            .ConstructUsing(dto => new Educator(
                Guid.NewGuid(),
                new FullName(dto.FullName.FirstName, dto.FullName.Surname, dto.FullName.Patronymic),
                dto.Gender,
                dto.BirthDate,
                dto.Phone,
                dto.WorkExperience));
        
        CreateMap<EducatorUpdateRequest, Educator>()
            .ConstructUsing(dto => new Educator(
                dto.Id,
                new FullName(dto.FullName.FirstName, dto.FullName.Surname, dto.FullName.Patronymic),
                dto.Gender,
                dto.BirthDate,
                dto.Phone,
                dto.WorkExperience));

        CreateMap<FullName, FullNameDto>();
        
        CreateMap<FullNameDto, FullName>();
    }
}