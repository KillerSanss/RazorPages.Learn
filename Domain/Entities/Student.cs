using Ardalis.GuardClauses;
using Domain.Entities.Base;
using Domain.Entities.ValueObjects;
using Domain.Primitieves.Enums;
using Domain.Validations;
using Domain.Validations.Validators;

namespace Domain.Entities;

/// <summary>
/// Сущность студента
/// </summary>
public class Student : BaseEntity
{
    /// <summary>
    /// Полное имя
    /// </summary>
    public FullName FullName { get; private set; }
    
    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; private set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; private set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="fullName">Имя.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="phone">Номер телефона.</param>
    /// <param name="email">Электронная почта.</param>
    public Student(
        Guid id,
        FullName fullName,
        Gender gender,
        DateTime birthDate,
        string phone,
        string email)
    {
        SetId(id);
        FullName = Guard.Against.Null(fullName);
        Gender = new EnumValidator<Gender>(nameof(gender), Gender.None).ValidateWithErrors(gender);
        BirthDate = new DateValidator(nameof(birthDate)).ValidateWithErrors(birthDate);
        Phone = new PhoneValidator(nameof(phone)).ValidateWithErrors(phone);
        Email = new EmailValidator(nameof(email)).ValidateWithErrors(email);
    }
    
    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="fullName">Имя.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="phone">Номер телефона.</param>
    /// <param name="email">"Электронная почта.</param>
    /// <returns>Обновленный студент.</returns>
    public Student Update(
        FullName fullName,
        Gender gender,
        DateTime birthDate,
        string phone,
        string email)
    {
        FullName = Guard.Against.Null(fullName);
        Gender = new EnumValidator<Gender>(nameof(gender), Gender.None).ValidateWithErrors(gender);
        BirthDate = new DateValidator(nameof(birthDate)).ValidateWithErrors(birthDate);
        Phone = new PhoneValidator(nameof(phone)).ValidateWithErrors(phone);
        Email = new EmailValidator(nameof(email)).ValidateWithErrors(email);
        
        return this;
    }
    
    public Student()
    {
    }
}