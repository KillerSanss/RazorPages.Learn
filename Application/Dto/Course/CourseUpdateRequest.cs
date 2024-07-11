namespace Application.Dto.Course;

/// <summary>
/// Дто для обновления курса
/// </summary>
public class CourseUpdateRequest : BaseCourseDto
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; init; }
}