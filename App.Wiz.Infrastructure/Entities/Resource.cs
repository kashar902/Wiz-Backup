using App.Wiz.Common.BaseEntity;
using App.Wiz.Common.ServiceViewModels.ResourcesViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("Resources")]
public class Resource : BaseEntities
{
    [Key]
    public int ID { get; set; }
    public string? ResourceName { get; set; }
    public string? Type { get; set; }
    public string? Path { get; set; }
    public string? Icon { get; set; }
    public ResourcesCategory? Category { get; set; }
    public int CategoryId { get; set; }

    public ICollection<UsersResource> UsersResources { get; set; }

    public ResourcesViewModel PrepareToViewModel()
    {
        return new()
        {
            CategoryId = CategoryId,
            Icon = Icon,
            Path = Path,
            Title = ResourceName,
            Type = Type
        };
    }
}
