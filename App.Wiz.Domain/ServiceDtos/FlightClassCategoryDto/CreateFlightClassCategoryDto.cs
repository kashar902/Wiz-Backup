using App.Wiz.Common.BaseEntity;
using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.FlightClassCategoryDto;

public class CreateFlightClassCategoryDto : CreateDtoBaseEntities
{
    [Required]
    public string? FlightClass { get; set; }
    public FlightClassCategory PrepareToEntity()
    {
        return new FlightClassCategory()
        {
            FlightClass = FlightClass,
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
        };
    }
}
