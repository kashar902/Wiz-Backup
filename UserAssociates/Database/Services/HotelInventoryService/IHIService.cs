using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.HotelInventoryService
{
    public interface IHIService
    {
        Task<List<HotelInventory>> GetAllHotelInventory();
    }
}
