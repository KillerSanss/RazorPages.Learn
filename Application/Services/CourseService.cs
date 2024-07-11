using Application.Dto.Course;
using Application.Exceptions;
using Application.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

/// <summary>
/// Сервис курса
/// </summary>
public class CourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = Guard.Against.Null(courseRepository);
        _mapper = mapper;
    }
    
    /// <summary>
    /// Получение всех курсов
    /// </summary>
    /// <returns>Список всех курсов.</returns>
    public List<CourseGetAllResponse> GetAll()
    {
        var courses = _courseRepository.GetAll();
        return _mapper.Map<List<CourseGetAllResponse>>(courses);
    }

    /// <summary>
    /// Получение курса
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <returns>Курс.</returns>
    public CourseGetByIdResponse GetById(Guid id)
    {
        var course = GetByIdOrThrow(id);
        return _mapper.Map<CourseGetByIdResponse>(course);
    }

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    public void Delete(Guid id)
    {
        var course = GetByIdOrThrow(id);
        _courseRepository.Delete(course);
        _courseRepository.SaveChanges();
    }
    
    /// <summary>
    /// Создание курса
    /// </summary>
    /// <param name="courseCreateRequest">Курс на создание.</param>
    /// <returns>Созданный курс.</returns>
    public CourseCreateResponse Create(CourseCreateRequest courseCreateRequest)
    {
        Guard.Against.Null(courseCreateRequest);
        var course = _mapper.Map<Course>(courseCreateRequest);
        var createdCourse = _courseRepository.Create(course);
        _courseRepository.SaveChanges();
        return _mapper.Map<CourseCreateResponse>(createdCourse);
    }
    
    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="courseUpdateRequest">Курс на обновление.</param>
    /// <returns>Обновленный курс.</returns>
    public CourseUpdateResponse Update(CourseUpdateRequest courseUpdateRequest)
    {
        Guard.Against.Null(courseUpdateRequest);

        var course = GetByIdOrThrow(courseUpdateRequest.Id);

        course.Update(
            courseUpdateRequest.Name,
            courseUpdateRequest.Description,
            courseUpdateRequest.StartDate,
            courseUpdateRequest.EducatorId);
        
        _courseRepository.Update(course);
        _courseRepository.SaveChanges();
        
        return _mapper.Map<CourseUpdateResponse>(course);
    }
    
    public List<CourseGetAllByEducatorIdResponse> GetAllByEducatorId(Guid id)
    {
        var courses = _courseRepository.GetAllByEducatorIdAsync(id);
        return _mapper.Map<List<CourseGetAllByEducatorIdResponse>>(courses);
    }
    
    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Курс.</returns>
    private Course GetByIdOrThrow(Guid id)
    {
        var course = _courseRepository.GetById(id);
        if (course == null)
        {
            throw new EntityNotFoundException<Course>(nameof(Course.Id), id.ToString());
        }

        return course;
    }
}