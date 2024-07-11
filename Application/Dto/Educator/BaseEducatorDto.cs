using Domain.Primitieves.Enums;

namespace Application.Dto.Educator;

/// <summary>
/// Базовое дто для преподавателя
/// </summary>
public class BaseEducatorDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public FullNameDto FullName { get; init; }

    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; init; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; init; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; init; }
    
    /// <summary>
    /// Опыт работы
    /// </summary>
    public int WorkExperience { get; init; }
}