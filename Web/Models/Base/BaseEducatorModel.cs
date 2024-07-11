using Application.Dto;
using Domain.Primitieves.Enums;

namespace Web.Models.Base;

public class BaseEducatorModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Полное имя
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