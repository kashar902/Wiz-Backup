using App.Wiz.Common.ServiceViewModels.ResourcesCategoryViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("ResourcesCategory")]
public class ResourcesCategory
{
    [Key]
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Icon { get; set; }
    public string? Type { get; set; }
    public string? Path { get; set; }
    public int Priority { get; set; }

    public ICollection<Resource>? Resources { get; set; }


    public ResourcesCategoryViewModel PrepareToViewModel()
    {
        return new()
        {
            ID = ID,
            Type = Type,
            Priority = Priority,
            Icon = Icon,
            Path = Path,
            Title = Title
        };
    }
}
