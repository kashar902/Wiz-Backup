using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Infrastructure.Entities;

public class AccBudgetPeriod
{
    [Key]
    public int ID { get; set; }
    public string? Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsFiscalYear { get; set; }
}
