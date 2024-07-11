using Application.Dto.Course;
using Web.Models.Base;

namespace Web.Models.Course;

public class CourseCreateViewModel : BaseCourseModel
{
    public IEnumerable<CourseCreateRequest> Course { get; init; }
}