using UserAssociates.Business.Dtos;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.ResourceGroupService;

namespace UserAssociates.Business.Logic.AssignResourceGroupBusiness
{
    public class ARGLogic : IARGLogic
    {
        private readonly IARGService _assignResourceGroupService;

        public ARGLogic(IARGService assignResourceGroupService)
        {
            _assignResourceGroupService = assignResourceGroupService;
        }
        public async Task<List<AssignResourceGroup>> GetAllAssignResourceGroup()
        {
            try
            {
                var value = await _assignResourceGroupService.GetAllResourceGroup();
                return value;
            }
            catch (CustomException)
            {
                throw;
            }
        }
        public async Task<string> AddResourceGroup(AssignResourceGroupDto argDto)
        {
            try
            {
                List<AssignResourceGroup> ls = new List<AssignResourceGroup>();
                for (int i = 0; i < argDto.Resources.Count; i++)
                {
                    AssignResourceGroup arg = new AssignResourceGroup();
                    arg.ResourceID = argDto.Resources[i].ID;
                    arg.GroupID = argDto.GroupID;
                    arg.GroupPriorityToUser = argDto.GroupPriorityToUser;
                    ls.Add(arg);
                }

                var _arg = new List<AssignResourceGroup>();

                for (int i = 0; i < ls.Count; i++)
                {
                    var resource = new AssignResourceGroup
                    {
                        ResourceID = ls[i].ResourceID,
                        GroupID = ls[i].GroupID,
                        GroupPriorityToUser = ls[i].GroupPriorityToUser
                    };

                    _arg.Add(resource);
                }

                var value = await _assignResourceGroupService.AddResourceGroup(_arg);
                return value;

            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
