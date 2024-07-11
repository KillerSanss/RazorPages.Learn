using Application.Dto.Course;
using AutoMapper;
using Domain.Entities;
using Web.Models.Course;

namespace Web.Mapping;

public class CourseModelMappingProfile : Profile
{
    public CourseModelMappingProfile()
    {
        CreateMap<CourseGetAllResponse, CourseGetAllViewModel>();

        CreateMap<CourseGetByIdResponse, CourseGetByIdViewModel>();
        
        CreateMap<Course, CourseGetAllByEducatorIdResponse>();

        CreateMap<CourseGetAllByEducatorIdResponse, CourseGetEducatorCoursesViewModel>();
    }
}