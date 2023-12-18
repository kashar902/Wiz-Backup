using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CatalystDateLockService;

namespace UserAssociates.Business.Logic.CatalystDateLockBusiness
{
    public class CDLLogic : ICDLLogic
    {
        private readonly ICDLService _catalystDateLockService;

        public CDLLogic(ICDLService catalystDateLockService)
        {
            _catalystDateLockService = catalystDateLockService;
        }
        public async Task<List<CatalystDateLock>> GetAllCatalystDateLockUserPref()
        {
            try
            {
                var value = await _catalystDateLockService.GetAllCatalystDateLock();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
