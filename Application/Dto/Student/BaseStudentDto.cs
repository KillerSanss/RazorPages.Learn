using Domain.Primitieves.Enums;

namespace Application.Dto.Student;

public class BaseStudentDto
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
    /// Электронная почта
    /// </summary>
    public string Email { get; init; }
}