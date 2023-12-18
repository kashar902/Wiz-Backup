using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("TemplateType")]
public class TemplateType
{
    public int ID { get; set; }
    public string? TypeCode { get; set; }
    public string? TypeName { get; set; }
}