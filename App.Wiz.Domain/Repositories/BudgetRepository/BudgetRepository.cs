using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.BudgetRepository;

public class BudgetRepository : Repository<AccBudget>, IBudgetRepository
{
    public BudgetRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }

    public async Task RemoveAsync(List<AccBudget> entity)
    {
        _dbContext.AccBudget.RemoveRange(entity);
        _ = await _dbContext.SaveChangesAsync();
    }

    public async Task<List<AccBudget>> GetAsync()
    {
        return await _dbContext.AccBudget
            .Include(x => x.Branch)
            .Include(x => x.Parent).ToListAsync();
    }
    public async Task<List<AccBudget>> GetAsync(Guid parentId)
    {
        return await _dbContext.AccBudget
            .Where(x => x.ParentId == parentId)
            .Include(x => x.Branch)
            .Include(x => x.Period)
            .Include(x => x.Parent).ToListAsync();
    }
    public async Task<AccBudget?> GetAsync(int branchId)
    {
        return await _dbContext.AccBudget.
            Include(x => x.Branch)
            .Include(x => x.Parent)
            .FirstOrDefaultAsync(x => x.BranchId == branchId);
    }
}