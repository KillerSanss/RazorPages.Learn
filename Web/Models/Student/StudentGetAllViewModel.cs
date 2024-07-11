using Application.Dto.Student;
using Web.Models.Base;

namespace Web.Models.Student;

public class StudentGetAllViewModel : BaseStudentModel
{
    public IEnumerable<StudentGetAllResponse> Students { get; init; }
}