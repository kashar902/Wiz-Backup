using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.LicenseDto;

public class CreateLicenseDto : CreateDtoBaseEntities
{
    public int LicenseCat { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
    public int BranchId { get; set; }
}