using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.AgencyDto;

public class UpdateAgencyDto : UpdateDtoBaseEntities
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public bool IsActive { get; set; }
    public string? OfficeAddress { get; set; }
    public string? Postalcode { get; set; }
    public int CompanyId { get; set; }
    public int CurrencyId { get; set; }
}