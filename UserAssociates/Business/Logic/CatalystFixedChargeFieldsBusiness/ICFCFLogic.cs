using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CatalystFixedChargeFieldsBusiness
{
    public interface ICFCFLogic
    {
        Task<List<CatalystFixedChargeFields>> GetAllCatalystFixedChargeFieldsUserPref();
    }
}
