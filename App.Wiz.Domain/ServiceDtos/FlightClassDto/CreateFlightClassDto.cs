using App.Wiz.Common.BaseEntity;
using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.FlightClassDto;

public class CreateFlightClassDto : CreateDtoBaseEntities
{
    [Required]
    public string? Title { get; set; }

    [Required]
    public int FlightClassCategoryId { get; set; }

    public string? Description { get; set; }

    public FlightClasses PrepareToEntity() 
    {
        return new FlightClasses()
        {
            Title = Title,
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            Description = Description,
            FlightClassCategoryId = FlightClassCategoryId,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
        };
    }
}