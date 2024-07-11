namespace Application.Dto.Educator;

/// <summary>
/// Дто ответа на получение всех преподавателей
/// </summary>
public class EducatorGetAllResponse : BaseEducatorDto
{
    public Guid Id { get; init; }
}