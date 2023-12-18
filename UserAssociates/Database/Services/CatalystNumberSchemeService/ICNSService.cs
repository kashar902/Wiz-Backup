using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystNumberSchemeService
{
    public interface ICNSService
    {
        Task<List<CatalystNumberScheme>> GetAllCatalystNumberScheme();
    }
}
