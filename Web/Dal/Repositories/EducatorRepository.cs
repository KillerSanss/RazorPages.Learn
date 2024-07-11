using Application.Interfaces;
using Domain.Entities;
using Web.Dal.Context;

namespace Web.Dal.Repositories;

/// <summary>
/// Репозиторий преподавателя
/// </summary>
public class EducatorRepository : IEducatorRepository
{
    private readonly MvcDbContext _dbContext;

    public EducatorRepository(MvcDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Получение преподавателя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Преподаватель.</returns>
    public Educator GetById(Guid id)
    {
        return _dbContext.Educators.FirstOrDefault(e => e.Id == id) ?? throw new InvalidOperationException();
    }

    /// <summary>
    /// Получение всех преподавателей
    /// </summary>
    /// <returns>Список преподавателей.</returns>
    public List<Educator> GetAll()
    {
        return _dbContext.Educators.ToList();
    }

    /// <summary>
    /// Добавление преподавателя в базу данных
    /// </summary>
    /// <param name="entity">Преподаватель на добавление.</param>
    /// <returns>Добавленный преподаватель.</returns>
    public Educator Create(Educator entity)
    {
        return _dbContext.Educators.Add(entity).Entity;
    }

    /// <summary>
    /// Обновление преподавателя в базе данных
    /// </summary>
    /// <param name="entity">Преподаватель на обновление.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public Educator Update(Educator entity)
    {
        return _dbContext.Educators.Update(entity).Entity;
    }

    /// <summary>
    /// Удаление преподавателя из базы
    /// </summary>
    /// <param name="entity">Преподаватель на удаление.</param>
    public void Delete(Educator entity)
    {
        _dbContext.Educators.Remove(entity);
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