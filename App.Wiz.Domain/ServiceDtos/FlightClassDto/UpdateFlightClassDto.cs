using App.Wiz.Common.BaseEntity;
using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.FlightClassDto;

public class UpdateFlightClassDto : UpdateDtoBaseEntities
{
    [Required]
    public int ID { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public int FlightClassCategoryId { get; set; }

    public string? Description { get; set; }

    public FlightClasses PrepareToEntity(FlightClasses flightClasses)
    {
        flightClasses.Title = Title;
        flightClasses.Description = Description;
        flightClasses.FlightClassCategoryId = FlightClassCategoryId;
        flightClasses.ModifiedBy = Global.Username;
        flightClasses.ModifiedDate = DateTime.UtcNow;
        return flightClasses;
    }
}
