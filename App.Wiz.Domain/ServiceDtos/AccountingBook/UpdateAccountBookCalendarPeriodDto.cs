using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.AccountingBook;

public class UpdateAccountBookCalendarPeriodDto : UpdateDtoBaseEntities
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public bool Status { get; set; }
}
