namespace Application.Dto;

/// <summary>
/// Дто полного имени
/// </summary>
public class FullNameDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; init; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; init; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; init; }
}