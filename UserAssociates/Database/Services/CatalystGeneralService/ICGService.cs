using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystGeneralService
{
    public interface ICGService
    {
        Task<List<CatalystGeneral>> GetAllCatalystGeneral();
    }
}
