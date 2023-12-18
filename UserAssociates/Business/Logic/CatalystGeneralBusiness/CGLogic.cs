using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CatalystGeneralService;

namespace UserAssociates.Business.Logic.CatalystGeneralBusiness
{
    public class CGLogic : ICGLogic
    {
        private readonly ICGService _catalystGeneralService;

        public CGLogic(ICGService catalystGeneralService)
        {
            _catalystGeneralService = catalystGeneralService;
        }

        public async Task<List<CatalystGeneral>> GetAllCatalystGeneralUserPref()
        {
            try
            {
                var value = await _catalystGeneralService.GetAllCatalystGeneral();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
