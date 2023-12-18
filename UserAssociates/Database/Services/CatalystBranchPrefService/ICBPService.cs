using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystBranchPrefService
{
    public interface ICBPService
    {
        Task<List<CatalystBranchPreferences>> GetAllCatalystBranchPreferences();
    }
}
