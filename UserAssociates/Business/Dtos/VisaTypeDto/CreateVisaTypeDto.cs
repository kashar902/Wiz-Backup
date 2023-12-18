using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.VisaTypeDto
{
    public class CreateVisaTypeDto
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}