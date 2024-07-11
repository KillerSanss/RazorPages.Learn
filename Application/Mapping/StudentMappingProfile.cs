using Application.Dto;
using Application.Dto.Student;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ValueObjects;

namespace Application.Mapping;

/// <summary>
/// Маппинг для студента
/// </summary>
public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, StudentGetByIdResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<Student, StudentGetAllResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
            
        CreateMap<Student, StudentCreateResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<Student, StudentUpdateResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<StudentCreateRequest, Student>()
            .ConstructUsing(dto => new Student(
                Guid.NewGuid(),
                new FullName(dto.FullName.FirstName, dto.FullName.Surname, dto.FullName.Patronymic),
                dto.Gender,
                dto.BirthDate,
                dto.Phone,
                dto.Email));
        
        CreateMap<StudentUpdateRequest, Student>()
            .ConstructUsing(dto => new Student(
                dto.Id,
                new FullName(dto.FullName.FirstName, dto.FullName.Surname, dto.FullName.Patronymic),
                dto.Gender,
                dto.BirthDate,
                dto.Phone,
                dto.Email));

        CreateMap<FullName, FullNameDto>();
        
        CreateMap<FullNameDto, FullName>();
    }
}