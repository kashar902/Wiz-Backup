using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystCheckboxService
{
    public interface ICCService
    {
        Task<List<CatalystCheckbox>> GetAllCatalystCheckbox();
    }
}
