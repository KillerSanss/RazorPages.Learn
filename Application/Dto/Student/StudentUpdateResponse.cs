namespace Application.Dto.Student;

/// <summary>
/// Дто ответа на обновление студента
/// </summary>
public class StudentUpdateResponse : BaseStudentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid Id { get; init; }
}