using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class AccSubsidaryAccount : BaseEntities
{
    [Key]
    public Guid ID { get; set; }
    public string Title { get; set; }
    public Guid ControlAccountId { get; set; }
    public string AccountCode { get; set; }
    public int CurrencyId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? OpeningBalance { get; set; }
    public DateTime? OpeningBalanceDate { get; set; }
    public decimal? ExchangeRate { get; set; }
    public int SuperTypeId { get; set; }
    public bool IsActive { get; set; }

    /// Relationship
    [ForeignKey("ControlAccountId")]
    public AccControlAccount ControlAccount { get; set; }
    [ForeignKey("SuperTypeId")]
    public AccSuperType SuperType { get; set; }
    [ForeignKey("CurrencyId")]
    public Currency Currency { get; set; }
}
