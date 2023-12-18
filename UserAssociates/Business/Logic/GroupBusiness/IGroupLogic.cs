using System.Text.RegularExpressions;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.GroupBusiness
{
    public interface IGroupLogic
    {
        Task<List<Groups>> GetAllGroups();
        Task<List<Groups>> AddGroup(Groups group);
    }
}
