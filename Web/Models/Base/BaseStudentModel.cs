using Application.Dto;
using Domain.Primitieves.Enums;

namespace Web.Models.Base;

public class BaseStudentModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
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
    /// Электронная почта
    /// </summary>
    public string Email { get; init; }
}