using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.ResourceRepository;

public class UserResourceRepository : Repository<UsersResource>, IUserResourceRepository
{
    public UserResourceRepository(CatalystWizDbContext context)
        : base(context)
    {

    }

    public async Task<List<UsersResource>> GetAllAsync(int userId)
    {
        return await _dbContext.UsersResources
            .Include(x => x.Resource)
            .ThenInclude(x => x.Category)
            .Include(x => x.Rights)
            .Where(x => x.UserId == userId )
            .ToListAsync();
    }
    public async Task<UsersResource?> GetAsync(int userId, int resourceId)
    {
        return await _dbContext.UsersResources
            .Include(x => x.Resource)
            .Include(x => x.Rights)
            .Where(x => x.UserId == userId && x.ResourceId == resourceId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<UsersResource>> GetAllAsync(int userId, int catId)
    {
        return await _dbContext.UsersResources
            .Include(x => x.Resource)
            .ThenInclude(x => x.Category)
            .Include(x => x.Rights)
            .Where(x => x.UserId == userId && x.Resource.CategoryId == catId)
            .ToListAsync();
    }
}
