using Application.Interfaces;
using Domain.Entities;
using Web.Dal.Context;

namespace Web.Dal.Repositories;

/// <summary>
/// Репозиторий курса
/// </summary>
public class CourseRepository : ICourseRepository
{
    private readonly MvcDbContext _dbContext;

    public CourseRepository(MvcDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Получение курса по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <returns>Выбранный курс.</returns>
    public Course GetById(Guid id)
    {
        return _dbContext.Courses.FirstOrDefault(с => с.Id == id) ?? throw new InvalidOperationException();
    }

    /// <summary>
    /// Получение всех курсов
    /// </summary>
    /// <returns>Список всех курсов.</returns>
    public List<Course> GetAll()
    {
        return _dbContext.Courses.ToList();
    }

    /// <summary>
    /// Добавление курса в базу данных
    /// </summary>
    /// <param name="entity">Курс на добавление</param>
    /// <returns>Добавленный курс.</returns>
    public Course Create(Course entity)
    {
        return _dbContext.Courses.Add(entity).Entity;
    }

    /// <summary>
    /// Обновление курса в базе данных
    /// </summary>
    /// <param name="entity">Курс на обновление.</param>
    /// <returns>Обновленный курс.</returns>
    public Course Update(Course entity)
    {
        return _dbContext.Courses.Update(entity).Entity;
    }

    /// <summary>
    /// Удаление курса из базы
    /// </summary>
    /// <param name="entity">Курс на удаление.</param>
    public void Delete(Course entity)
    {
        _dbContext.Courses.Remove(entity);
    }
    
    /// <summary>
    /// Получение всех курсов преподавателя.
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <returns>Список курсов преподавателя.</returns>
    public List<Course> GetAllByEducatorIdAsync(Guid id)
    {
        return _dbContext.Courses.Where(e => e.EducatorId == id).ToList();
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