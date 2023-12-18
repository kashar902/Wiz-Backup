using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.VisaSMSBusiness
{
    public interface IVSLogic
    {
        Task<List<VisaSMS>> GetAllVisaSMSPref();
    }
}
