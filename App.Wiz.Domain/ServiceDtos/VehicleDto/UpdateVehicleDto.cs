using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.VehicleDto
{
    public class UpdateVehicleDto : UpdateDtoBaseEntities
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Make { get; set; }
        [Required]
        public string? Model { get; set; }
        public string? RegistrationNo { get; set; }
        public string? Description { get; set; }
        public new string? ModifiedBy { get; set; }

    }
}
