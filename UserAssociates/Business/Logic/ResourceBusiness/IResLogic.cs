using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.ResourceBusiness
{
    public interface IResLogic
    {
        Task<List<Resources>> GetAllResources();

        Task<List<Resources>> AddResource(Resources resource);
    }
}
