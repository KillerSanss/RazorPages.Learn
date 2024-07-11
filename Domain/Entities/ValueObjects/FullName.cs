using Domain.Validations;
using Domain.Validations.Validators;

namespace Domain.Entities.ValueObjects;

/// <summary>
/// Полное имя
/// </summary>
public class FullName
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; set; }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="surname">Фамилия.</param>
    /// <param name="patronymic">Отчество.</param>
    public FullName(string firstName, string surname, string patronymic)
    {
        FirstName = new FullNameValidator(nameof(firstName)).ValidateWithErrors(firstName);
        Surname = new FullNameValidator(nameof(surname)).ValidateWithErrors(surname); 
        Patronymic = new FullNameValidator(nameof(patronymic)).ValidateWithErrors(patronymic);
    }
}