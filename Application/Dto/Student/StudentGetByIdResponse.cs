namespace Application.Dto.Student;

/// <summary>
/// Дто ответа на получение студента
/// </summary>
public class StudentGetByIdResponse : BaseStudentDto
{
    public Guid Id { get; init; }
}