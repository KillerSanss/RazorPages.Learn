namespace Application.Dto.Student;

/// <summary>
/// Дто ответа на получение всех студентов
/// </summary>
public class StudentGetAllResponse : BaseStudentDto
{
    public Guid Id { get; init; }
}