using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.BookingCategoryService;

public interface IBookingCategoryService
{
    Task<BookingCategory> AddBookingCategory(BookingCategory bookingCategory);
    Task<int> DeleteBookingCategory(BookingCategory bookingCategory);
    Task<List<BookingCategory>> GetAllBookingCategories();
    Task<BookingCategory?> GetBookingCategory(int Id);
    Task<int> UpdateBookingCategory(BookingCategory bookingCategory);
}
