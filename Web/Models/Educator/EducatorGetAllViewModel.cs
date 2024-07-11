using Application.Dto.Educator;
using Web.Models.Base;

namespace Web.Models.Educator;

public class EducatorGetAllViewModel : BaseEducatorModel
{
    public IEnumerable<EducatorGetAllResponse> Educators { get; init; }
}