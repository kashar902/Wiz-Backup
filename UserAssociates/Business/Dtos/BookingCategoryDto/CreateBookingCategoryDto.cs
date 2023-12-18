using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.BookingCategoryDto;

public class CreateBookingCategoryDto
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public int CategoryType { get; set; }
}
