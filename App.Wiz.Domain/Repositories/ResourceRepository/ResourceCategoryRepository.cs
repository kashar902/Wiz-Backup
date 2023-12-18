using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.ResourceRepository;

public class ResourceCategoryRepository : Repository<ResourcesCategory>, IResourceCategoryRepository
{
    public ResourceCategoryRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
    public async Task<List<ResourcesCategory>> GetCotegoriesResources(int userId)
    {
        List<ResourcesCategory> response = await _dbContext.ResourcesCategories
                    .Include(x => x.Resources!)
                    .ThenInclude(x => x.UsersResources.Where(x => x.UserId == userId))
                    .ThenInclude(x => x.User!.UserGroups!)
                    .ThenInclude(x => x.Group!.GroupDetails)
                    .OrderBy(x => x.Priority).ToListAsync();


        //    IQueryable<ResourcesCategory> response = _dbContext.ResourcesCategories
        //.Include(x => x.Resources)!
        //.ThenInclude(x => x.UsersResources!.Where(x => x.UserId == userId))
        //.ThenInclude(x => x.User)
        //.ThenInclude(user => user!.UserGroups!.Where(x => x.UserId == userId))
        //.ThenInclude(x => x.Group)
        //.ThenInclude(group => group!.GroupDetails)
        //.OrderBy(x => x.Priority);
        return  response;
    }
}
