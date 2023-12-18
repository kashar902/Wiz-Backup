using UserAssociates.Business.Dtos;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.GeneralService;
using UserAssociates.Database.Services.MemberGroupService;

namespace UserAssociates.Business.Logic.AssignMemberGroupBusiness
{
    public class AMGLogic : IAMGLogic
    {
        private readonly IAMGService _assignMemberService;
        private readonly IGService _generalService;

        public AMGLogic(IAMGService assignMemberService, IGService generalService)
        {
            _assignMemberService = assignMemberService;
            _generalService = generalService;

        }

        public async Task<string> AddMemberGroup(AssignMemberGroupDto amgDto)
        {
            try
            {
                List<AssignMemberGroup> ls = new List<AssignMemberGroup>();
                for (int i = 0; i < amgDto.Users.Count; i++)
                {
                    AssignMemberGroup amg = new AssignMemberGroup();
                    amg.AssignedUserId = amgDto.Users[i].AuthenticationUserId;
                    amg.GroupId = amgDto.GroupID;
                    amg.GroupPriorityToUser = amgDto.GroupPriorityToUser;
                    ls.Add(amg);
                }

                var _amg = new List<AssignMemberGroup>();

                for (int i = 0; i < ls.Count; i++)
                {
                    var member = new AssignMemberGroup
                    {
                        AssignedUserId = ls[i].AssignedUserId,
                        GroupId = ls[i].GroupId,
                        GroupPriorityToUser = ls[i].GroupPriorityToUser
                    };

                    _amg.Add(member);
                }

                var value = await _assignMemberService.AddMemberGroup(_amg);
                return value;

            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<List<AssignMemberGroup>> GetAllAssignMemberGroup()
        {
            try
            {
                var value = await _assignMemberService.GetAllMemberGroup();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
