using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public sealed class AccountSetup : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? CustomerId { get; set; }
    public string? SupplierId { get; set; }
    public string? VoidCharge { get; set; }
    public string? BalanceEquity { get; set; }
    public string? ExchangeDiff { get; set; }
}
