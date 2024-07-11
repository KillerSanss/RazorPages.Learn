using Application.Dto.Educator;
using AutoMapper;
using Web.Models.Educator;

namespace Web.Mapping;

public class EducatorModelMappingProfile : Profile
{
    public EducatorModelMappingProfile()
    {
        CreateMap<EducatorGetAllResponse, EducatorGetAllViewModel>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<EducatorGetByIdResponse, EducatorGetByIdViewModel>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
    }
}