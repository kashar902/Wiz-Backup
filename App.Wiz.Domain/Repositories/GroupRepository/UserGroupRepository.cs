using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Wiz.Domain.Repositories.GroupRepository;

public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
{
    public UserGroupRepository(CatalystWizDbContext context)
        : base(context)
    {

    }

    public async Task<List<UserGroup>> GetUserGroups(int userId) 
    {
        return await _dbContext.UserGroups.Include(x => x.Group).Where(x => x.UserId == userId).ToListAsync();
    }

}
