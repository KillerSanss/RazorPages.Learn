using Application.Dto.Student;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Student;

namespace Web.Controllers;

/// <summary>
/// Контроллер студента
/// </summary>
public class StudentController : Controller
{
    private readonly StudentService _studentService;
    private readonly IMapper _mapper;

    public StudentController(StudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Начальная страница студентов
    /// </summary>
    /// <returns>Все студенты.</returns>
    public ActionResult Index(string searchString, int? pageNumber)
    {
        ViewBag.CurrentFilter = searchString;
        
        var students = _studentService.GetAll();
        
        if (!string.IsNullOrEmpty(searchString))
        {
            students = students.Where(c => c.FullName.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                         c.FullName.Surname.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                         c.FullName.Patronymic.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        int pageSize = 5;
        int currentPage = pageNumber ?? 1;
        
        var pagedStudents = students.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.TotalPages = (int)Math.Ceiling(students.Count / (double)pageSize);
        ViewBag.CurrentPage = currentPage;

        return View(_mapper.Map<List<StudentGetAllViewModel>>(pagedStudents));
    }
    
    /// <summary>
    /// Данные об одном студенте
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <returns>Студент.</returns>
    public ActionResult Details(Guid id)
    {
        var student = _studentService.GetById(id);
        return View(_mapper.Map<StudentGetByIdViewModel>(student));
    }

    /// <summary>
    /// Переход на страницу создания студента
    /// </summary>
    public ActionResult Create()
    {
        return View();
    }
    
    /// <summary>
    /// Создание студента
    /// </summary>
    /// <param name="studentCreateRequest">Данные для создания студента.</param>
    [HttpPost]
    public ActionResult Create(StudentCreateRequest studentCreateRequest)
    {
        _studentService.Create(studentCreateRequest);
        return RedirectToAction(nameof(Index));
    }
    
    /// <summary>
    /// Переход на страницу обновления студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    public ActionResult Edit(Guid id)
    {
        var student = _studentService.GetById(id);
        return View(_mapper.Map<StudentGetByIdViewModel>(student));
    }
    
    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentUpdateRequest">Данные для обновления студента.</param>
    [HttpPost]
    public ActionResult EditConfirmed(StudentUpdateRequest studentUpdateRequest)
    {
        _studentService.Update(studentUpdateRequest);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    [HttpPost]
    public ActionResult Delete(Guid id)
    {
        _studentService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}