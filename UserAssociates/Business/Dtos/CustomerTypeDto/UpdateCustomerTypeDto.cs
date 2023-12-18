using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.CustomerTypeDto
{
    public class UpdateCustomerTypeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? TypeName { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
