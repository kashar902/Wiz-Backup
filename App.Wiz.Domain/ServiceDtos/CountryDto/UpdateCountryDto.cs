using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.CountryDto;

public class UpdateCountryDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? CountryName { get; set; }
    [Required]
    public string? CountryCode { get; set; }
}
