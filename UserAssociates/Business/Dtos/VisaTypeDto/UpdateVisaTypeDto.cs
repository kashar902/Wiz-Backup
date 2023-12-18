using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.VisaTypeDto
{
    public class UpdateVisaTypeDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}