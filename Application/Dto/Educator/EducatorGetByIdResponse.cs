namespace Application.Dto.Educator;

/// <summary>
/// Дто ответа на получение преподавателя
/// </summary>
public class EducatorGetByIdResponse : BaseEducatorDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid Id { get; init; }
}