using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models;

public sealed class ChargeField : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KeyID { get; set; }
    public string? FieldCode { get; set; }
    public string? ChargeFieldName { get; set; }
    public string? FieldType { get; set; }
    public string? ChargeType { get; set; }
    public string? Position { get; set; }
    public string? Percentage { get; set; }
    public bool RoundOff { get; set; }
    public bool IsReadOnly { get; set; }
    public string? Description { get; set; }
}
