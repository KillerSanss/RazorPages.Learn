using Application.Dto.Course;
using Web.Models.Base;

namespace Web.Models.Course;

public class CourseGetAllViewModel : BaseCourseModel
{
    public IEnumerable<CourseGetAllResponse> Educators { get; init; }
}