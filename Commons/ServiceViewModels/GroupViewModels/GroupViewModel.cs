using App.Wiz.Common.ServiceViewModels.AssignedResourceToGroupViewModels;

namespace App.Wiz.Common.ServiceViewModels.GroupViewModels;

public class GroupViewModel
{
    public int ID { get; set; }
    public string? GroupName { get; set; }
    public int GroupPriority { get; set; }
    public string? Description { get; set; }
    public List<AssignedResourceToGroupViewModel>? ResourceDetails { get; set; }
}
