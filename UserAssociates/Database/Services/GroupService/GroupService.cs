using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;

        public GroupService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Groups>> GetAllGroups()
        {
            var groups = await _dbContext.Groups.ToListAsync();
            return groups;
        }

        public async Task<List<Groups>> AddGroup(Groups group)
        {
            _dbContext.Groups.Add(group);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Groups.ToListAsync();
        }

    }
}
