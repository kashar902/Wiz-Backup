using UserAssociates.Business.Dtos.BookingCategoryDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.BookingCategoryBusinessLogic;

public interface IBookingCategoryLogic
{
    Task<string> CreateBookingCategory(CreateBookingCategoryDto bookingCategoryDto);
    Task<string> UpdateBookingCategory(UpdateBookingCategoryDto updateBookingCategoryDto);
    Task<BookingCategoryViewModel?> GetBookingCategory(int Id);
    Task<List<BookingCategory>> GetAllBookingCategories();
    Task<string> DeleteBookingCategory(int id);
}
