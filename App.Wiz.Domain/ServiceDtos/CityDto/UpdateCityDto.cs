using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.CityDto;

public class UpdateCityDto : UpdateDtoBaseEntities
{

    [Required]
    public int Id { get; set; }
    [Required]
    public string? CityName { get; set; }
    [Required]
    public string? CityCode { get; set; }
    [Required]
    public int CountryId { get; set; }
}