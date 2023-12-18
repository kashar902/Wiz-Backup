namespace App.Wiz.Common.ServiceViewModels.ResourcesViewModels;

public class ResourcesRightsViewModel
{
    public int ResourceId { get; set; }
    public string? ResourceName { get; set; }
    public bool IsCreated { get; set; }
    public bool IsDelete { get; set; }
    public bool IsRead { get; set; }
    public bool IsUpdate { get; set; }
}
