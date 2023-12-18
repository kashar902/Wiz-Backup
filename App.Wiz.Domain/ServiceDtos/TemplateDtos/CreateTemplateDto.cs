using App.Wiz.Common.Enums;
using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.ServiceDtos.TemplateDtos;

public class CreateTemplateDto
{
    public CreateTemplateDto()
    {
        CreateTemplateFieldDtos = new List<CreateTemplateFieldDto>();
    }
    public string? TemplateTitle { get; set; }
    public string? TemplateDescription { get; set; }
    public int TemplateTypeId { get; set; }

    public List<CreateTemplateFieldDto> CreateTemplateFieldDtos { get; set; }

    public Template PrepareToTemplate()
    {
        return new Template
        {
            Title = TemplateTitle,
            Description = TemplateDescription,
            TemplateTypeId = TemplateTypeId,
            CreatedBy = Global.Username + ", " + Global.UserId,
            ModifiedBy = Global.Username + ", " + Global.UserId,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };
    }
}
