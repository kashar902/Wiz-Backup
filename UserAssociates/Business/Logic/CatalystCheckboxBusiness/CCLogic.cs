using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CatalystCheckboxService;

namespace UserAssociates.Business.Logic.CatalystCheckboxBusiness
{
    public class CCLogic : ICCLogic
    {
        private readonly ICCService _catalystCheckboxService;

        public CCLogic(ICCService catalystCheckboxService)
        {
            _catalystCheckboxService = catalystCheckboxService;
        }

        public async Task<List<CatalystCheckbox>> GetAllCatalystCheckboxUserPref()
        {
            try
            {
                var value = await _catalystCheckboxService.GetAllCatalystCheckbox();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
