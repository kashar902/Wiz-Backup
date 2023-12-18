using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.MemberGroupService
{
    public interface IAMGService
    {
        Task<List<AssignMemberGroup>> GetAllMemberGroup();
        Task<string> AddMemberGroup(List<AssignMemberGroup> amg);

    }
}
