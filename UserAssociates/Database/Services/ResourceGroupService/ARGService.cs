using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.ResourceGroupService
{
    public class ARGService : IARGService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;
        public ARGService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<AssignResourceGroup>> GetAllResourceGroup()
        {
            var arg = await _dbContext.AssignResourcetoGroup.ToListAsync();
            return arg;
        }

        public async Task<string> AddResourceGroup(List<AssignResourceGroup> arg)
        {
            _dbContext.AssignResourcetoGroup.AddRange(arg);
            await _dbContext.SaveChangesAsync();
            return "Resource assigned successfully";
        }

    }
}
