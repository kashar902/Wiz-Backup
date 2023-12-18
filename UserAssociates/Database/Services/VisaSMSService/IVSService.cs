using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VisaSMSService
{
    public interface IVSService
    {
        Task<List<VisaSMS>> GetAllVisaSMS();
    }
}
