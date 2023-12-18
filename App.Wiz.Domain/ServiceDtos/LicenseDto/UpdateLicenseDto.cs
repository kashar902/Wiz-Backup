using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.LicenseDto;

public class UpdateLicenseDto : UpdateDtoBaseEntities
{
    public int ID { get; set; }
    public int LicenseCat { get; set; }
    public DateTime startdate { get; set; }
    public DateTime enddate { get; set; }
    public int BranchId { get; set; }
}