namespace App.Wiz.Common.ServiceViewModels.GroupViewModels;

public class GetAllGroupsViewModel
{
    public int? ID { get; set; }
    public string? GroupName { get; set; }
    public int? GroupPriority { get; set; }
    public string? Description { get; set; }
    public bool IsChecked { get; set; }
}