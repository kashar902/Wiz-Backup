using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CatalystDateLockBusiness
{
    public interface ICDLLogic
    {
        Task<List<CatalystDateLock>> GetAllCatalystDateLockUserPref();
    }
}
