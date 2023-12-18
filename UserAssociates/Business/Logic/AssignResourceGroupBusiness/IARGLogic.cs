using UserAssociates.Business.Dtos;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.AssignResourceGroupBusiness
{
    public interface IARGLogic
    {
        Task<List<AssignResourceGroup>> GetAllAssignResourceGroup();
        Task<string> AddResourceGroup(AssignResourceGroupDto arg);
    }
}
