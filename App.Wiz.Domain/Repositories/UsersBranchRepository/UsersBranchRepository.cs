using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.UsersBranchRepository;

public class UsersBranchRepository : Repository<UsersBranch>, IUsersBranchRepository
{
    public UsersBranchRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
    public async Task<UsersBranch?> GetAsync(int userId)
    {
        return await _dbContext.UserBranch
            .Include(x => x.User)
            .Include(x => x.Branch)
            .Include(x => x.Companies)
            .Include(x => x.GroupOfCompany)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
    public async Task<UsersBranch?> GetAsync(int userId, int branchId)
    {
        return await _dbContext.UserBranch
            .Include(x => x.User)
            .Include(x => x.Branch)
            .Include(x => x.Companies)
            .Include(x => x.GroupOfCompany)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.BranchId == branchId);
    }
    public async Task<UsersBranch?> GetAsync(int userId, bool defaultBranch)
    {
        return await _dbContext.UserBranch
            .Include(x => x.User)
            .Include(x => x.Branch)
            .Include(x => x.Companies)
            .Include(x => x.GroupOfCompany)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.DefaultBranch == defaultBranch);
    }
    public async Task<List<UsersBranch>> GetUserBranchesAsync(int userId)
    {
        return await _dbContext.UserBranch
            .Include(x => x.User)
            .Include(x => x.Branch)
            .Include(x => x.Companies)
            .Include(x => x.GroupOfCompany)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<UsersBranch>> GetBranchesByUserId(int userId)
    {
        return await _dbContext.UserBranch
            .Include(x => x.Branch)
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }
    public async Task<UsersBranch?> GetDefaultUserAgency(int userId)
    {
        return await _dbContext.UserBranch
            .Include(x => x.Branch)
            .Where(a => a.UserId == userId && a.DefaultBranch)
            .FirstOrDefaultAsync();
    }

}
