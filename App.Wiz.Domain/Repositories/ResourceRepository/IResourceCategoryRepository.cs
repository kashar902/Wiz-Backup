using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.ResourceRepository;

public interface IResourceCategoryRepository : IRepository<ResourcesCategory>
{
    Task<List<ResourcesCategory>> GetCotegoriesResources(int userId);
}
