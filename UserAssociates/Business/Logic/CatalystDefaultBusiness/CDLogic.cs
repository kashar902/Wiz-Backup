using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CatalystDefaultService;

namespace UserAssociates.Business.Logic.CatalystDefaultBusiness
{
    public class CDLogic : ICDLogic
    {
        private readonly ICDService _catalystDefaultService;

        public CDLogic(ICDService catalystDefaultService)
        {
            _catalystDefaultService = catalystDefaultService;
        }

        public async Task<List<CatalystDefault>> GetAllCatalystDefaultUserPref()
        {
            try
            {
                var value = await _catalystDefaultService.GetAllCatalystDefault();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
