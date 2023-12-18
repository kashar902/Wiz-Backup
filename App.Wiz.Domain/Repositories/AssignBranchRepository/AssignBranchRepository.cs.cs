using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.AssignBranchRepository;

public class AssignBranchRepository : Repository<AccAssignBranch>, IAssignBranchRepository
{
    public AssignBranchRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }

    public async Task RemoveAsync(List<AccAssignBranch> entity)
    {
        _dbContext.AccAssignBranch.RemoveRange(entity);
        _ = await _dbContext.SaveChangesAsync();
    }
    public async Task<List<AccAssignBranch>> GetAllAsync(int branchId)
    {
        return await _dbContext.AccAssignBranch.
            Include(x => x.Branch)
            .Include(x => x.Company)
            .Where(x => x.BranchId == branchId)
            .ToListAsync();
    }
    public async Task<List<AccAssignBranch>> GetAsync()
    {
        return await _dbContext.AccAssignBranch
            .Include(x => x.Branch)
            .Include(x => x.Company).ToListAsync();
    }
    public async Task<List<AccAssignBranch>> GetAsync(string parentId)
    {
        return await _dbContext.AccAssignBranch
            .Where(x => x.ParentId == parentId)
            .Include(x => x.Branch)
            .Include(x => x.Company).ToListAsync();
    }
    public async Task<AccAssignBranch?> GetAsync(int branchId)
    {
        return await _dbContext.AccAssignBranch.
            Include(x => x.Branch)
            .Include(x => x.Company)
            .FirstOrDefaultAsync(x => x.BranchId == branchId);
    }
    public async Task<AccAssignBranch?> GetAsync(int branchId, string parentId)
    {
        return await _dbContext.AccAssignBranch.
            Include(x => x.Branch)
            .Include(x => x.Company)
            .FirstOrDefaultAsync(x => x.BranchId == branchId && x.ParentId == parentId);
    }
}