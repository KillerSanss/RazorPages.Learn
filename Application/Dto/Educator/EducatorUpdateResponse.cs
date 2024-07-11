namespace Application.Dto.Educator;

/// <summary>
/// Дто ответа на обновление преподавателя
/// </summary>
public class EducatorUpdateResponse : BaseEducatorDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid Id { get; init; }
}