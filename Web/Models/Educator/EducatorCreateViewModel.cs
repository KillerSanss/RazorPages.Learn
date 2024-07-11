using Application.Dto.Educator;
using Web.Models.Base;

namespace Web.Models.Educator;

public class EducatorCreateViewModel : BaseEducatorModel
{
    public IEnumerable<EducatorCreateRequest> Educator { get; init; }
}