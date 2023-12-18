using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.GroupOfCompaniesDto;

public class CreateGroupOfCompanyDto : CreateDtoBaseEntities
{
    public string? GroupName { get; set; }
    [StringLength(500)]
    public string? GroupDescription { get; set; }
    public string? StartDate { get; set; }
    public bool Active { get; set; }
    public int CurrencyId { get; set; }
}