using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.VoucherType
{
    public class UpdateVoucherTypeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Prefix { get; set; }
        [Required]
        public string? Type { get; set; }
    }
}
