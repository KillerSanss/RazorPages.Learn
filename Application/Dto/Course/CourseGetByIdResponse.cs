namespace Application.Dto.Course;

/// <summary>
/// Дто ответа на получение курса
/// </summary>
public class CourseGetByIdResponse : BaseCourseDto
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; init; }
}