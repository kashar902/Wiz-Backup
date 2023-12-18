using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public sealed class ChargeField : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Code { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Position { get; set; }
    public int? FieldTypeId { get; set; }
    public int? ChargeTypeId { get; set; }
    public bool? IsReadOnly { get; set; }
    public bool? IsPercent { get; set; }
    public bool? IsRoundOff { get; set; }

    [ForeignKey("FieldTypeId")]
    public FieldType? FieldType { get; set; }
    [ForeignKey("ChargeTypeId")]
    public ChargeType? ChargeType { get; set; }
}
