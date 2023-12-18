using UserAssociates.Business.Dtos;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.AssignMemberGroupBusiness
{
    public interface IAMGLogic
    {
        Task<List<AssignMemberGroup>> GetAllAssignMemberGroup();
        Task<string> AddMemberGroup(AssignMemberGroupDto amg);
    }
}
