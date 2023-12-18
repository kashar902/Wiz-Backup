using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.ResourceService
{
    public interface IResService
    {
        Task<List<Resources>> GetAllResources();
        Task<List<Resources>> AddResource(Resources resource);
    }
}
