using Web.Models.Base;

namespace Web.Models.Educator;

public class EducatorGetByIdViewModel : BaseEducatorModel
{
    public IEnumerable<EducatorGetByIdViewModel> Educator { get; init; }
}