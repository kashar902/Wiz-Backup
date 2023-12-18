using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CatalystBranchPrefService;

namespace UserAssociates.Business.Logic.CatalystBranchPreferenceBusiness
{
    public class CBPLogic : ICBPLogic
    {
        private readonly ICBPService _catalystBranchPrefService;

        public CBPLogic(ICBPService catalystBranchPrefService)
        {
            _catalystBranchPrefService = catalystBranchPrefService;
        }
        public async Task<List<CatalystBranchPreferences>> GetAllCatalystBranchPref()
        {
            try
            {
                var value = await _catalystBranchPrefService.GetAllCatalystBranchPreferences();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
