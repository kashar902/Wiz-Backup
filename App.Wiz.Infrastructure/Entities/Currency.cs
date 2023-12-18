using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class Currency : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? CurrencyCode { get; set; }
    public string? CurrencyName { get; set; }
    public string? CurrencySymbol { get; set; }
    public string? Description { get; set; }
    public string? DecimalSeparator { get; set; }
    public string? Precision { get; set; }
    public string? ThousandSeparator { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public bool ActivateCurrency { get; set; }
}
