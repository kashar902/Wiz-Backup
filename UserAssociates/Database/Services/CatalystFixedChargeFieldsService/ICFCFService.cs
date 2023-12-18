using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CatalystFixedChargeFieldsService
{
    public interface ICFCFService
    {
        Task<List<CatalystFixedChargeFields>> GetAllCatalystFixedChargeFields();
    }
}
