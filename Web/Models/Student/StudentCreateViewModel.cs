using Application.Dto.Student;
using Web.Models.Base;

namespace Web.Models.Student;

public class StudentCreateViewModel : BaseStudentModel
{
    public IEnumerable<StudentCreateRequest> Students { get; init; }
}