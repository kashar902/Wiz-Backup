using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.HotelInventoryService
{
    public class HIService : IHIService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public HIService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<HotelInventory>> GetAllHotelInventory()
        {
            var hotelInventory = await _dbContext.Userpref_HotelInventory.ToListAsync();
            return hotelInventory;
        }
    }
}
