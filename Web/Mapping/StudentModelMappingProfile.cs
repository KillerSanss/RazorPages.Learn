using Application.Dto.Student;
using AutoMapper;
using Web.Models.Student;

namespace Web.Mapping;

public class StudentModelMappingProfile : Profile
{
    public StudentModelMappingProfile()
    {
        CreateMap<StudentGetAllResponse, StudentGetAllViewModel>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<StudentGetByIdResponse, StudentGetByIdViewModel>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
    }
}