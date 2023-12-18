using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.GroupRepository
{
    public class GroupDetailRepository : Repository<GroupDetails>, IGroupDetailRepository
    {
        public GroupDetailRepository(CatalystWizDbContext context)
       : base(context)
        {

        }

        public async Task<List<GroupDetails>> GetAllByGroupIdAsync(int groupId) 
        {
            return await _dbContext
                .GroupDetails
                .Include(x => x.Resource)
                .Include(x => x.AccessRight)
                .Where(x => x.GroupId == groupId).ToListAsync();
        }
    }
}
