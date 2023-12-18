using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystDefaultService
{
    public interface ICDService
    {
        Task<List<CatalystDefault>> GetAllCatalystDefault();
    }
}
