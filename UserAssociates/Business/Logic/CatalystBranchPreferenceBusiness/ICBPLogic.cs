using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CatalystBranchPreferenceBusiness
{
    public interface ICBPLogic
    {
        Task<List<CatalystBranchPreferences>> GetAllCatalystBranchPref();
    }
}
