using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CatalystCheckboxBusiness
{
    public interface ICCLogic
    {
        Task<List<CatalystCheckbox>> GetAllCatalystCheckboxUserPref();
    }
}
