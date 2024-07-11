using Application.Dto.Course;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

/// <summary>
/// Маппинг для курса
/// </summary>
public class CourseMappingProfile : Profile
{
    public CourseMappingProfile()
    {
        CreateMap<Course, CourseGetByIdResponse>();

        CreateMap<Course, CourseGetAllResponse>();

        CreateMap<Course, CourseCreateResponse>();

        CreateMap<Course, CourseUpdateResponse>();

        CreateMap<CourseCreateRequest, Course>()
            .ConstructUsing(dto => new Course(
                Guid.NewGuid(),
                dto.Name,
                dto.Description,
                dto.StartDate,
                dto.EducatorId));

        CreateMap<CourseUpdateRequest, Course>()
            .ConstructUsing(dto => new Course(
                dto.Id,
                dto.Name,
                dto.Description,
                dto.StartDate,
                dto.EducatorId));
    }
}