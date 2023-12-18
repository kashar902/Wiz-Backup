using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.CityDto;

public class CreateCityDto : CreateDtoBaseEntities
{
    [Required]
    public string? CityName { get; set; }
    [Required]
    public string? CityCode { get; set; }
    [Required]
    public int CountryId { get; set; }
}
