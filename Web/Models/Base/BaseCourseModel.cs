namespace Web.Models.Base;

public class BaseCourseModel
{
    public Guid Id { get; init; }
    
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