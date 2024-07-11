using Application.Dto.Educator;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Course;
using Web.Models.Educator;

namespace Web.Controllers;

/// <summary>
/// Контроллер преподавателя
/// </summary>
public class EducatorController : Controller
{
    private readonly EducatorService _educatorService;
    private readonly CourseService _courseService;
    private readonly IMapper _mapper;

    public EducatorController(
        EducatorService educatorService,
        CourseService courseService,
        IMapper mapper)
    {
        _educatorService = educatorService;
        _courseService = courseService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Начальная страница преподавателей
    /// </summary>
    /// <returns>Все преподаватели.</returns>
    public ActionResult Index(string searchString, int? pageNumber)
    {
        ViewBag.CurrentFilter = searchString;
        
        var educators = _educatorService.GetAll();
        
        if (!string.IsNullOrEmpty(searchString))
        {
            educators = educators.Where(c => c.FullName.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                           c.FullName.Surname.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                                           c.FullName.Patronymic.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        int pageSize = 5;
        int currentPage = pageNumber ?? 1;
        
        var pagedEducators = educators.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.TotalPages = (int)Math.Ceiling(educators.Count / (double)pageSize);
        ViewBag.CurrentPage = currentPage;
        
        return View(_mapper.Map<List<EducatorGetAllViewModel>>(pagedEducators));
    }
    
    /// <summary>
    /// Данные об одном преподавателе
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <returns>Преподаватель.</returns>
    public ActionResult Details(Guid id)
    {
        var educator = _educatorService.GetById(id);
        return View(_mapper.Map<EducatorGetByIdViewModel>(educator));
    }

    /// <summary>
    /// Переход на страницу создания преподавателя
    /// </summary>
    public ActionResult Create()
    {
        return View();
    }
    
    /// <summary>
    /// Создание преподавателя
    /// </summary>
    /// <param name="educatorCreateRequest">Данные для создания преподавателя.</param>
    [HttpPost]
    public ActionResult Create(EducatorCreateRequest educatorCreateRequest)
    {
        _educatorService.Create(educatorCreateRequest);
        return RedirectToAction(nameof(Index));
    }
    
    /// <summary>
    /// Переход на страницу обновления преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    public ActionResult Edit(Guid id)
    {
        var educator = _educatorService.GetById(id);
        return View(_mapper.Map<EducatorGetByIdViewModel>(educator));
    }
    
    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educatorUpdateRequest">Данные для обновления преподавателя.</param>
    [HttpPost]
    public ActionResult EditConfirmed(EducatorUpdateRequest educatorUpdateRequest)
    {
        _educatorService.Update(educatorUpdateRequest);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    [HttpPost]
    public ActionResult Delete(Guid id)
    {
        _educatorService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Получение курсов преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="searchString">Строка поиска.</param>
    /// <param name="pageNumber">Номер страницы.</param>
    /// <returns>Курсы преподавателя.</returns>
    [HttpGet]
    public ActionResult EducatorCourses(Guid id, string searchString, int? pageNumber)
    {
        ViewBag.CurrentFilter = searchString;
        
        var courses = _courseService.GetAllByEducatorId(id);
        var educator = _educatorService.GetById(id);

        ViewBag.Educator = $"{educator.FullName.FirstName} {educator.FullName.Surname} {educator.FullName.Patronymic}";
        
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
        
        return View(_mapper.Map<List<CourseGetEducatorCoursesViewModel>>(pagedCourses));
    }
}