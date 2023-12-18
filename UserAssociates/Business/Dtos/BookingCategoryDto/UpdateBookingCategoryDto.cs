using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.BookingCategoryDto;

public class UpdateBookingCategoryDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public int CategoryType { get; set; }
}
