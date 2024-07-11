using Web.Models.Base;

namespace Web.Models.Course;

public class CourseGetByIdViewModel : BaseCourseModel
{
    public IEnumerable<CourseGetByIdViewModel> Educator { get; init; }
}