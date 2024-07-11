using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Репозиторий курса
/// </summary>
public interface ICourseRepository : IBaseRepository<Course>
{
    /// <summary>
    /// Получение всех курсов преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <returns></returns>
    List<Course> GetAllByEducatorIdAsync(Guid id);
}