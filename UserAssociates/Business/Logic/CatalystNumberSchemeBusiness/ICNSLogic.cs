using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CatalystNumberSchemeBusiness
{
    public interface ICNSLogic
    {
        Task<List<CatalystNumberScheme>> GetAllCatalystNumberSchemeUserPref();
    }
}
