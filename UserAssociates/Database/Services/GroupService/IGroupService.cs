using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.GroupService
{
    public interface IGroupService
    {
        Task<List<Groups>> GetAllGroups();
        Task<List<Groups>> AddGroup(Groups group);
    }
}
