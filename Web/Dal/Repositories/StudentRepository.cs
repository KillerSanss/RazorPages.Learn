using Application.Interfaces;
using Domain.Entities;
using Web.Dal.Context;

namespace Web.Dal.Repositories;

/// <summary>
/// Репозиторий студента
/// </summary>
public class StudentRepository : IStudentRepository
{
    private readonly MvcDbContext _dbContext;

    public StudentRepository(MvcDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Получение студента по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Студент.</returns>
    public Student GetById(Guid id)
    {
        return _dbContext.Students.FirstOrDefault(s => s.Id == id) ?? throw new InvalidOperationException();
    }

    /// <summary>
    /// Получение всех студентов
    /// </summary>
    /// <returns>Список студентов.</returns>
    public List<Student> GetAll()
    {
        return _dbContext.Students.ToList();
    }

    /// <summary>
    /// Добавление студента в базу данных
    /// </summary>
    /// <param name="entity">Студент на добавление.</param>
    /// <returns>Добавленный студент.</returns>
    public Student Create(Student entity)
    {
        return _dbContext.Students.Add(entity).Entity;
    }

    /// <summary>
    /// Обновление студента в базе данных
    /// </summary>
    /// <param name="entity">Студент на обновление.</param>
    /// <returns>Обновленный студент.</returns>
    public Student Update(Student entity)
    {
        return _dbContext.Update(entity).Entity;
    }

    /// <summary>
    /// Удаление студента из базы
    /// </summary>
    /// <param name="entity">Студент на удаление.</param>
    public void Delete(Student entity)
    {
        _dbContext.Students.Remove(entity);
    }

    /// <summary>
    /// Сохранение в базу данных
    /// </summary>
    public Task SaveChanges()
    {
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}