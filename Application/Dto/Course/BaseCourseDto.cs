namespace Application.Dto.Course;

/// <summary>
/// Базовое дто для курса
/// </summary>
public class BaseCourseDto
{
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Описание курса
    /// </summary>
    public string Description { get; init; }
    
    /// <summary>
    /// Дата начала курса
    /// </summary>
    public DateTime StartDate { get; init; }
    
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid EducatorId { get; init; }
}