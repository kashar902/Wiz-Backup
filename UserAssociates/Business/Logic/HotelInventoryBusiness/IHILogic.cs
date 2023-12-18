using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.HotelInventoryBusiness
{
    public interface IHILogic
    {
        Task<List<HotelInventory>> GetAllHotelInventoryPref();
    }
}
