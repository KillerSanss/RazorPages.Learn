using Application.Dto.Student;
using Application.Exceptions;
using Application.Interfaces;
using Ardalis.GuardClauses;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Services;

/// <summary>
/// Сервис студента
/// </summary>
public class StudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = Guard.Against.Null(studentRepository);
        _mapper = mapper;
    }
    
    /// <summary>
    /// Получение всех студент
    /// </summary>
    /// <returns>Список всех студентов.</returns>
    public List<StudentGetAllResponse> GetAll()
    {
        var students = _studentRepository.GetAll();
        return _mapper.Map<List<StudentGetAllResponse>>(students);
    }
    
    /// <summary>
    /// Получение студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <returns>Студент.</returns>
    public StudentGetByIdResponse GetById(Guid id)
    {
        var student = GetByIdOrThrow(id);
        return _mapper.Map<StudentGetByIdResponse>(student);
    }

    public void Delete(Guid id)
    {
        var student = GetByIdOrThrow(id);
        _studentRepository.Delete(student);
        _studentRepository.SaveChanges();
    }
    
    /// <summary>
    /// Создание студента
    /// </summary>
    /// <param name="studentCreateRequest">Студента на создание.</param>
    /// <returns>Созданный студента.</returns>
    public StudentCreateResponse Create(StudentCreateRequest studentCreateRequest)
    {
        Guard.Against.Null(studentCreateRequest);

        var student = _mapper.Map<Student>(studentCreateRequest);
        var createdStudent = _studentRepository.Create(student);
        _studentRepository.SaveChanges();
        return _mapper.Map<StudentCreateResponse>(createdStudent);
    }
    
    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentUpdateRequest">Студент на обновление.</param>
    /// <returns>Обновленный студент.</returns>
    public StudentUpdateResponse Update(StudentUpdateRequest studentUpdateRequest)
    {
        Guard.Against.Null(studentUpdateRequest);

        var student = GetByIdOrThrow(studentUpdateRequest.Id);

        student.Update(
            new FullName(studentUpdateRequest.FullName.FirstName,
                studentUpdateRequest.FullName.Surname,
                studentUpdateRequest.FullName.Patronymic),
            studentUpdateRequest.Gender,
            studentUpdateRequest.BirthDate,
            studentUpdateRequest.Phone,
            studentUpdateRequest.Email);
        
        _studentRepository.Update(student);
        _studentRepository.SaveChanges();
        
        return _mapper.Map<StudentUpdateResponse>(student);
    }
    
    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Студент.</returns>
    private Student GetByIdOrThrow(Guid id)
    {
        var student = _studentRepository.GetById(id);
        if (student == null)
        {
            throw new EntityNotFoundException<Student>(nameof(Student.Id), id.ToString());
        }

        return student;
    }
}