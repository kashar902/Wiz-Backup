using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.BookingCategoryService;

public class BookingCategoryService : IBookingCategoryService
{
    private readonly UserAndAssociatesdbcontext _dbContext;
    public BookingCategoryService(UserAndAssociatesdbcontext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BookingCategory> AddBookingCategory(BookingCategory bookingCategory)
    {
        EntityEntry<BookingCategory> entityEntry = await _dbContext.AddAsync(bookingCategory);
        _ = await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<int> DeleteBookingCategory(BookingCategory bookingCategory)
    {
        _ = _dbContext.BookingCategories.Remove(bookingCategory);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<BookingCategory>> GetAllBookingCategories()
    {
        return await _dbContext.BookingCategories.ToListAsync();
    }
    public async Task<BookingCategory?> GetBookingCategory(int Id)
    {
        return await _dbContext.BookingCategories.FirstOrDefaultAsync(x => x.ID == Id);
    }

    public async Task<int> UpdateBookingCategory(BookingCategory bookingCategory)
    {
        _dbContext.Entry(bookingCategory).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync();
    }

}
