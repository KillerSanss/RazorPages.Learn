namespace Application.Dto.Educator;

/// <summary>
/// Дто для обновления преподавателя
/// </summary>
public class EducatorUpdateRequest : BaseEducatorDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid Id { get; init; }
}