using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.CountryDto;

public class CreateCountryDto
{
    [Required]
    public string? CountryName { get; set; }
    [Required]
    public string? CountryCode { get; set; }
}
