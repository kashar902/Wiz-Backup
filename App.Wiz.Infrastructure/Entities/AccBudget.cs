using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class AccBudget : BaseEntities
{
    [Key]
    public int ID { get; set; }
    public Guid ParentId { get; set; }
    public AccSubsidaryAccount? Parent { get; set; }
    public decimal Amount { get; set; }
    public int PeriodId { get; set; }
    public AccBudgetPeriod? Period { get; set; }
    public int BranchId { get; set; }

    //[ForeignKey("PeriodId")]
    //public AccBudgetPeriod AccBudgetPeriod { get; set; }
    [ForeignKey("BranchId")]
    public Branch? Branch { get; set; }
}
