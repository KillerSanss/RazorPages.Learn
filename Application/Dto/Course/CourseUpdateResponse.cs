namespace Application.Dto.Course;

/// <summary>
/// Дто ответа на обновление курса
/// </summary>
public class CourseUpdateResponse : BaseCourseDto
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; init; }
}