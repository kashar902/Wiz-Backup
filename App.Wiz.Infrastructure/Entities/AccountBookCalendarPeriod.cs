using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Infrastructure.Entities;

public class AccountBookCalendarPeriod : BaseEntities
{
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool? Status { get; set; }
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }
}

