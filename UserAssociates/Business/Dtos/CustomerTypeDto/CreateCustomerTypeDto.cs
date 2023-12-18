using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.CustomerTypeDto
{
    public class CreateCustomerTypeDto
    {
        [Required]
        public string? TypeName { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
