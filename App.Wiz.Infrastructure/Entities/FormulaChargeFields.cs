using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("FormulaChargeFields")]
public class FormulaChargeFields
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int FormulaId { get; set; }
    public int ChargeFieldId { get; set; }
}
