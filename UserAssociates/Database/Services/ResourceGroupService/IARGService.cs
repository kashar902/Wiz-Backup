using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.ResourceGroupService
{
    public interface IARGService
    {
        Task<List<AssignResourceGroup>> GetAllResourceGroup();
        Task<string> AddResourceGroup(List<AssignResourceGroup> arg);
    }
}
