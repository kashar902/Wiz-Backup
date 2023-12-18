using App.Wiz.Common.BaseEntity;
using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.FlightClassCategoryDto;

public class UpdateFlightClassCategoryDto : UpdateDtoBaseEntities
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? FlightClass { get; set; }


    public FlightClassCategory PrepareToEntity(FlightClassCategory flightClass)
    {
        flightClass.FlightClass = FlightClass;
        flightClass.ModifiedBy = Global.Username;
        flightClass.ModifiedDate = DateTime.UtcNow;
        return flightClass;
    }
}
