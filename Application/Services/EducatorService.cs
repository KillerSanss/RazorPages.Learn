using Application.Dto.Educator;
using Application.Exceptions;
using Application.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ValueObjects;

namespace Application.Services;

/// <summary>
/// Сервис преподавателя
/// </summary>
public class EducatorService
{
    private readonly IEducatorRepository _educatorRepository;
    private readonly IMapper _mapper;

    public EducatorService(IEducatorRepository educatorRepository, IMapper mapper)
    {
        _educatorRepository = Guard.Against.Null(educatorRepository);
        _mapper = mapper;
    }
    
    /// <summary>
    /// Получение всех преподавателей
    /// </summary>
    /// <returns>Список всех преподавателей.</returns>
    public List<EducatorGetAllResponse> GetAll()
    {
        var educators = _educatorRepository.GetAll();
        return _mapper.Map<List<EducatorGetAllResponse>>(educators);
    }
    
    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <returns>Преподаватель.</returns>
    public EducatorGetByIdResponse GetById(Guid id)
    {
        var educator = GetByIdOrThrow(id);
        return _mapper.Map<EducatorGetByIdResponse>(educator);
    }

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    public void Delete(Guid id)
    {
        var course = GetByIdOrThrow(id);
        _educatorRepository.Delete(course);
        _educatorRepository.SaveChanges();
    }
    
    /// <summary>
    /// Создание преподаватель
    /// </summary>
    /// <param name="educatorCreateRequest">Преподаватель на создание.</param>
    /// <returns>Созданный преподаватель.</returns>
    public EducatorCreateResponse Create(EducatorCreateRequest educatorCreateRequest)
    {
        Guard.Against.Null(educatorCreateRequest);
        var educator = _mapper.Map<Educator>(educatorCreateRequest);
        var createdEducator = _educatorRepository.Create(educator);
        _educatorRepository.SaveChanges();
        return _mapper.Map<EducatorCreateResponse>(createdEducator);
    }
    
    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educatorUpdateRequest">Преподаватель на обновление.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public EducatorUpdateResponse Update(EducatorUpdateRequest educatorUpdateRequest)
    {
        Guard.Against.Null(educatorUpdateRequest);

        var educator = GetByIdOrThrow(educatorUpdateRequest.Id);

        educator.Update(
            new FullName(educatorUpdateRequest.FullName.FirstName,
                educatorUpdateRequest.FullName.Surname,
                educatorUpdateRequest.FullName.Patronymic),
            educatorUpdateRequest.Gender,
            educatorUpdateRequest.BirthDate,
            educatorUpdateRequest.Phone,
            educatorUpdateRequest.WorkExperience);
        
        _educatorRepository.Update(educator);
        _educatorRepository.SaveChanges();
        
        return _mapper.Map<EducatorUpdateResponse>(educator);
    }
    
    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Преподаватель.</returns>
    private Educator GetByIdOrThrow(Guid id)
    {
        var educator = _educatorRepository.GetById(id);
        if (educator == null)
        {
            throw new EntityNotFoundException<Educator>(nameof(Educator.Id), id.ToString());
        }

        return educator;
    }
}