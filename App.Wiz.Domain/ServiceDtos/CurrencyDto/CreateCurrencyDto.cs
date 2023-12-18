using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.CurrencyDto;

public class CreateCurrencyDto : CreateDtoBaseEntities
{
    [Required]
    public string? CurrencyCode { get; set; }
    [Required]
    public string? CurrencyName { get; set; }
    [Required]
    public string? CurrencySymbol { get; set; }
    public string? Description { get; set; }
    public string? DecimalSeparator { get; set; }
    public string? Precision { get; set; }
    public string? ThousandSeparator { get; set; }
    public DateTime EffectiveDate { get; set; }
    public bool ActivateCurrency { get; set; }

}
