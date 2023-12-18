using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CatalystDefaultBusiness
{
    public interface ICDLogic
    {
        Task<List<CatalystDefault>> GetAllCatalystDefaultUserPref();
    }
}
