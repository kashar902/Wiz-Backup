using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.ServiceDtos.TemplateDtos;

public class UpdateTemplateDto
{
    public UpdateTemplateDto()
    {
        UpdateTemplateFieldDtos = new List<UpdateTemplateFieldDto>();
    }
    public int TemplateId { get; set; }
    public string? TemplateTitle { get; set; }
    public string? TemplateDescription { get; set; }

    public List<UpdateTemplateFieldDto> UpdateTemplateFieldDtos { get; set; }


public Template PrepareToTemplate(Template entity)
    {
        entity.Title = TemplateTitle;
        entity.Description = TemplateDescription;
        entity.ModifiedBy = Global.Username + ", " + Global.UserId;
        entity.ModifiedDate = DateTime.UtcNow;
        return entity;
    }
}