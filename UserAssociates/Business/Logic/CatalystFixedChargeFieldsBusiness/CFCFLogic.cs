using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CatalystFixedChargeFieldsService;

namespace UserAssociates.Business.Logic.CatalystFixedChargeFieldsBusiness
{
    public class CFCFLogic : ICFCFLogic
    {
        private readonly ICFCFService _catalystFixedChargeFieldsService;

        public CFCFLogic(ICFCFService catalystFixedChargeFieldsService)
        {
            _catalystFixedChargeFieldsService = catalystFixedChargeFieldsService;
        }
        public async Task<List<CatalystFixedChargeFields>> GetAllCatalystFixedChargeFieldsUserPref()
        {
            try
            {
                var value = await _catalystFixedChargeFieldsService.GetAllCatalystFixedChargeFields();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
