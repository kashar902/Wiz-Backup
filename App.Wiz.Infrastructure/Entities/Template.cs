using App.Wiz.Common.BaseEntity;
using App.Wiz.Common.ServiceViewModels.TemplateViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("Template")]
public class Template : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public int TemplateTypeId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public TemplateType? TemplateType { get; set; }
    public ICollection<TemplateField>? TemplateFields { get; set; }

    public TemplateViewModel PrepareToViewModel()
    {
        return new TemplateViewModel
        {
            TemplateId = ID,
            TemplateTitle = Title,
            TemplateDescription = Description,
            TypeName = TemplateType?.TypeName
        };
    }
}