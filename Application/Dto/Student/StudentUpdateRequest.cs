namespace Application.Dto.Student;

/// <summary>
/// Дто для обновления студента
/// </summary>
public class StudentUpdateRequest : BaseStudentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid Id { get; init; }
}