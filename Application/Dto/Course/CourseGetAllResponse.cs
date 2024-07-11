namespace Application.Dto.Course;

/// <summary>
/// Дто ответа на получение всех курсов
/// </summary>
public class CourseGetAllResponse : BaseCourseDto
{
    public Guid Id { get; init; }
}