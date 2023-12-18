using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CatalystNumberSchemeService;

namespace UserAssociates.Business.Logic.CatalystNumberSchemeBusiness
{
    public class CNSLogic : ICNSLogic
    {
        private readonly ICNSService _catalystNumberSchemeService;

        public CNSLogic(ICNSService catalystNumberSchemeService)
        {
            _catalystNumberSchemeService = catalystNumberSchemeService;
        }

        public async Task<List<CatalystNumberScheme>> GetAllCatalystNumberSchemeUserPref()
        {
            try
            {
                var value = await _catalystNumberSchemeService.GetAllCatalystNumberScheme();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
