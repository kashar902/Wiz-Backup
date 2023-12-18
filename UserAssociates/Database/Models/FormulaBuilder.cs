using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models;

public sealed class FormulaBuilder : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KeyID { get; set; }
    public string? FormulaCode { get; set; }
    public string? FormulaName { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public string? Formula { get; set; }
    public bool Active { get; set; }
}
