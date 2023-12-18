namespace App.Wiz.Common.ServiceViewModels.ResourcesViewModels;

public class UserAssignedResourcesViewModel
{
    public UserAssignedResourcesViewModel()
    {
        MenuItems = new List<ResourceCategory>();
    }
    public List<ResourceCategory> MenuItems { get; set; }
}

public class ResourceCategory 
{
    public ResourceCategory()
    {
        children = new List<Resources>();
    }
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Icon { get; set; }
    public string? Type { get; set; }
    public string? Path { get; set; }
    public int Priority { get; set; }

    public List<Resources> children { get; set; }
}

public class Resources
{
    public string? Title { get; set; }
    public string? Type { get; set; }
    public string? Path { get; set; }
    public string? Icon { get; set; }
    public int? CategoryId { get; set; }
}