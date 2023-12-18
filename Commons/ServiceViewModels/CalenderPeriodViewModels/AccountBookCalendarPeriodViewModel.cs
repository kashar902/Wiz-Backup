namespace App.Wiz.Common.ServiceViewModels.CalenderPeriodViewModels;

public class AccountBookCalendarPeriodViewModel
{
    public int ID { get; set; }
    public string? CompanyName { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool? Status { get; set; }
    public bool? Checked { get; set; }
}
