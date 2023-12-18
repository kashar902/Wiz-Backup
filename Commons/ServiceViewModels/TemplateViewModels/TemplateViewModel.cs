namespace App.Wiz.Common.ServiceViewModels.TemplateViewModels;

public class TemplateViewModel
{
    public int TemplateId { get; set; }
    public string? TemplateTitle { get; set; }
    public string? TemplateDescription { get; set; }
    public string? TypeName { get; set; }

    public List<TemplateFieldsViewModel?>?  TemplateFields { get; set; }
}
