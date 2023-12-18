using UserAssociates.Database.Models;
using UserAssociates.Database.Services.HotelInventoryService;

namespace UserAssociates.Business.Logic.HotelInventoryBusiness
{
    public class HILogic : IHILogic
    {
        private readonly IHIService _hotelInventoryService;

        public HILogic(IHIService hotelInventoryService)
        {
            _hotelInventoryService = hotelInventoryService;
        }
        public async Task<List<HotelInventory>> GetAllHotelInventoryPref()
        {
            try
            {
                var value = await _hotelInventoryService.GetAllHotelInventory();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
