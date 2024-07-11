using Ardalis.GuardClauses;
using Domain.Entities.Base;
using Domain.Entities.ValueObjects;
using Domain.Primitieves.Enums;
using Domain.Validations;
using Domain.Validations.Validators;

namespace Domain.Entities;

/// <summary>
/// Сущнсоть преподавателя
/// </summary>
public class Educator : BaseEntity
{
    /// <summary>
    /// Список курсов
    /// </summary>
    public readonly List<Course> Courses = new();
    
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
    /// Опыт работы
    /// </summary>
    public int WorkExperience { get; private set; }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="fullName">Имя.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="phone">Номер телефона.</param>
    /// <param name="workExperience">Опыт работы.</param>
    public Educator(
        Guid id,
        FullName fullName,
        Gender gender,
        DateTime birthDate,
        string phone,
        int workExperience)
    {
        SetId(id);
        FullName = Guard.Against.Null(fullName);
        Gender = new EnumValidator<Gender>(nameof(gender), Gender.None).ValidateWithErrors(gender);
        BirthDate = new DateValidator(nameof(birthDate)).ValidateWithErrors(birthDate);
        Phone = new PhoneValidator(nameof(phone)).ValidateWithErrors(phone);
        WorkExperience = new WorkExperienceValidator(nameof(workExperience)).ValidateWithErrors(workExperience);
    }
    
    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="fullName">Имя.</param>
    /// <param name="gender">Гендер.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="phone">Номер телефона.</param>
    /// <param name="workExperience">Опыт работы.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public Educator Update(
        FullName fullName,
        Gender gender,
        DateTime birthDate,
        string phone,
        int workExperience)
    {
        FullName = Guard.Against.Null(fullName);
        Gender = new EnumValidator<Gender>(nameof(gender), Gender.None).ValidateWithErrors(gender);
        BirthDate = new DateValidator(nameof(birthDate)).ValidateWithErrors(birthDate);
        Phone = new PhoneValidator(nameof(phone)).ValidateWithErrors(phone);
        WorkExperience = new WorkExperienceValidator(nameof(workExperience)).ValidateWithErrors(workExperience);
        
        return this;
    }
    
    public Educator()
    {
    }
}