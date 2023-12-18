using App.Wiz.Common.BaseEntity;

namespace App.Wiz.Domain.ServiceDtos.CompanyDto;

public class UpdateCompanyDto : UpdateDtoBaseEntities
{
    public int ID { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyDescription { get; set; }
    public string? Masking { get; set; }
    public string? StartDate { get; set; }
    public bool Active { get; set; }
    public int GroupOfCompanyId { get; set; }
    public int CurrencyId { get; set; }
}