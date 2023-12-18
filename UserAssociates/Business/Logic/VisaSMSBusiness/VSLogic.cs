using UserAssociates.Database.Models;
using UserAssociates.Database.Services.VisaSMSService;

namespace UserAssociates.Business.Logic.VisaSMSBusiness
{
    public class VSLogic : IVSLogic
    {
        private readonly IVSService _visaSmsService;

        public VSLogic(IVSService visaSmsService)
        {
            _visaSmsService = visaSmsService;
        }

        public async Task<List<VisaSMS>> GetAllVisaSMSPref()
        {
            try
            {
                var value = await _visaSmsService.GetAllVisaSMS();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
