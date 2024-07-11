using Application.Dto.Course;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Course;

namespace Web.Controllers;

/// <summary>
/// Контроллер курса
/// </summary>
public class CourseController : Controller
{
    private readonly CourseService _courseService;
    private readonly IMapper _mapper;
        
    public CourseController(CourseService courseService, IMapper mapper)
    {
        _courseService = courseService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Начальная страница курсов
    /// </summary>
    /// <returns>Все курсы.</returns>
    public ActionResult Index(string searchString, int? pageNumber)
    {
        ViewBag.CurrentFilter = searchString;
        
        var courses = _courseService.GetAll();
        
        if (!string.IsNullOrEmpty(searchString))
        {
            courses = courses.Where(c => c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                         c.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        int pageSize = 5;
        int currentPage = pageNumber ?? 1;
        
        var pagedCourses = courses.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.TotalPages = (int)Math.Ceiling(courses.Count / (double)pageSize);
        ViewBag.CurrentPage = currentPage;
        
        return View(_mapper.Map<List<CourseGetAllViewModel>>(pagedCourses));
    }
    
    /// <summary>
    /// Данные об одном курсе
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <returns>Курс.</returns>
    public ActionResult Details(Guid id)
    {
        var course = _courseService.GetById(id);
        return View(_mapper.Map<CourseGetByIdViewModel>(course));
    }

    /// <summary>
    /// Переход на страницу создания курса
    /// </summary>
    public ActionResult Create()
    {
        return View();
    }
    
    /// <summary>
    /// Создание курса
    /// </summary>
    /// <param name="courseCreateRequest">Данные для создания курса.</param>
    [HttpPost]
    public ActionResult Create(CourseCreateRequest courseCreateRequest)
    {
        _courseService.Create(courseCreateRequest);
        return RedirectToAction(nameof(Index));
    }
    
    /// <summary>
    /// Переход на страницу обновления курса
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    public ActionResult Edit(Guid id)
    {
        var course = _courseService.GetById(id);
        return View(_mapper.Map<CourseGetByIdViewModel>(course));
    }
    
    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="courseUpdateRequest">Данные для обновления курса.</param>
    [HttpPost]
    public ActionResult EditConfirmed(CourseUpdateRequest courseUpdateRequest)
    {
        _courseService.Update(courseUpdateRequest);
        return RedirectToAction(nameof(Index));
    }
    
    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    [HttpPost]
    public ActionResult Delete(Guid id)
    {
        _courseService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}