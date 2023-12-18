using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CatalystGeneralBusiness
{
    public interface ICGLogic
    {
        Task<List<CatalystGeneral>> GetAllCatalystGeneralUserPref();
    }
}
