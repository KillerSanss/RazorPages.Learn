using Ardalis.GuardClauses;
using Domain.Entities.Base;
using Domain.Validations;
using Domain.Validations.Validators;

namespace Domain.Entities;

/// <summary>
/// Сущность курса
/// </summary>
public class Course : BaseEntity
{
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Описание курса
    /// </summary>
    public string Description { get; private set; }
        
    /// <summary>
    /// Дата начала курса
    /// </summary>
    public DateTime StartDate { get; private set; }
    
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid EducatorId { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="name">Название курса.</param>
    /// <param name="description">Описание курса.</param>
    /// <param name="startDate">Дата начала курса.</param>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    public Course(
        Guid id,
        string name,
        string description,
        DateTime startDate,
        Guid educatorId)
    {
        SetId(id);
        Name = new StringValidator(nameof(name)).ValidateWithErrors(name);
        Description = new StringValidator(nameof(description)).ValidateWithErrors(description);
        StartDate = new DateValidator(nameof(startDate)).ValidateWithErrors(startDate);
        EducatorId = Guard.Against.Null(educatorId);
    }
    
    /// <summary>
    /// Обновление курса.
    /// </summary>
    /// <param name="name">Название курса.</param>
    /// <param name="description">Описание курса.</param>
    /// <param name="startDate">Дата начала курса.</param>
    /// <param name="educatorId">Индентификатор преподавателя.</param>
    /// <returns>Обновленный курс.</returns>
    public Course Update(
        string name,
        string description,
        DateTime startDate,
        Guid educatorId)
    {
        Name = new StringValidator(nameof(name)).ValidateWithErrors(name);
        Description = new StringValidator(nameof(description)).ValidateWithErrors(description);
        StartDate = new DateValidator(nameof(startDate)).ValidateWithErrors(startDate);
        EducatorId = Guard.Against.Null(educatorId);
        
        return this;
    }

    public Course()
    {
    }
}