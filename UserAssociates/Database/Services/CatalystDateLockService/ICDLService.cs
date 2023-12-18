using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystDateLockService
{
    public interface ICDLService
    {
        Task<List<CatalystDateLock>> GetAllCatalystDateLock();
    }
}
