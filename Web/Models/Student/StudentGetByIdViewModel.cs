using Web.Models.Base;

namespace Web.Models.Student;

public class StudentGetByIdViewModel : BaseStudentModel
{
    public IEnumerable<StudentGetByIdViewModel> Student { get; init; }
}