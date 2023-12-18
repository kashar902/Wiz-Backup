using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.ResourceService
{
    public class ResService : IResService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;
        public ResService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Resources>> GetAllResources()
        {
            var resources = await _dbContext.Resource.ToListAsync();
            return resources;
        }

        public async Task<List<Resources>> AddResource(Resources resource)
        {
            _dbContext.Resource.Add(resource);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Resource.ToListAsync();
        }
    }
}
