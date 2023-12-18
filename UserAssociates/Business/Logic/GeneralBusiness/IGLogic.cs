using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.GeneralBusiness
{
    public interface IGLogic
    {
        Task<List<General>> GetAllGeneralUserPref();
    }
}
