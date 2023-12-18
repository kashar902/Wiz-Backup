using UserAssociates.Database.Models;
using UserAssociates.Database.Services.GroupService;

namespace UserAssociates.Business.Logic.GroupBusiness
{
    public class GroupLogic : IGroupLogic
    {
        private readonly IGroupService _groupService;

        public GroupLogic(IGroupService groupService)
        {
            _groupService = groupService;
        }
        public async Task<List<Groups>> GetAllGroups()
        {
            try
            {
                var value = await _groupService.GetAllGroups();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
        public async Task<List<Groups>> AddGroup(Groups group)
        {

            try
            {
                group.Creation_Date = DateTime.Now;
                var value = await _groupService.AddGroup(group);
                return value;

            }
            catch (CustomException)
            {
                throw;
            }
        }

    }
}
