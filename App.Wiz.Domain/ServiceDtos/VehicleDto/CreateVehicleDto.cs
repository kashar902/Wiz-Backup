using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.VehicleDto
{
    public class CreateVehicleDto : CreateDtoBaseEntities
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        public string? RegistrationNo { get; set; }
        public string? Description { get; set; }

    }
}
