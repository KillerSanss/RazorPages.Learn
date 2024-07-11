using Application.Dto.Course;
using Web.Models.Base;

namespace Web.Models.Course;

public class CourseGetEducatorCoursesViewModel : BaseCourseModel
{
    public IEnumerable<CourseGetAllByEducatorIdResponse> Courses { get; init; }
}