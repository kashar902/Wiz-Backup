using App.Wiz.Common.ServiceViewModels.ResourcesViewModels;

namespace App.Wiz.Common.ServiceViewModels.ResourcesCategoryViewModel;
public class ResourcesCategoryViewModel
{
    public ResourcesCategoryViewModel()
    {
        ResourcesViewModel = new List<ResourcesViewModel>();
    }
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Icon { get; set; }
    public string? Type { get; set; }
    public string? Path { get; set; }
    public int Priority { get; set; }

    public List<ResourcesViewModel>? ResourcesViewModel { get; set; }
}
