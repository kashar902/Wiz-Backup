using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.GeneralService
{
    public interface IGService
    {
        Task<List<General>> GetAllGeneralUserPref();
    }
}
