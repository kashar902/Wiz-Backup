using UserAssociates.Database.Models;
using UserAssociates.Database.Services.GeneralService;

namespace UserAssociates.Business.Logic.GeneralBusiness
{
    public class GLogic : IGLogic
    {
        private readonly IGService _generalService;

        public GLogic(IGService generalService)
        {
            _generalService = generalService;
        }

        public async Task<List<General>> GetAllGeneralUserPref()
        {
            try
            {
                var value = await _generalService.GetAllGeneralUserPref();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
