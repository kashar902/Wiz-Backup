using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.AgencyViewModels;
using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Wiz.Domain.Repositories.BranchRepository;

public class BranchRepository : Repository<Branch>, IBranchRepository
{
    public BranchRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }
    public async Task AddBranch(Branch branch)
    {
        _ = _dbContext.Branch.Add(branch);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Branch?> GetSingleBranch(int id)
    {
        Branch? agency = await _dbContext.Branch
            .Include(x => x.Company)
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.ID == id);
        return agency is null ? null : agency;
    }

    public async Task UpdateBranchAsync(Branch branch)
    {
        branch.ModifiedBy = Global.Username;
        branch.ModifiedDate = DateTime.UtcNow;
        _dbContext.Entry(branch).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Branch>> GetAllBranches()
    {
        List<AgencyViewModel> list = new();
        return await _dbContext.Branch
            .Include(x => x.Company)
            .Include(x => x.Currency)
            .ToListAsync();
    }

    public async Task DeleteBranch(Branch branch)
    {
        _ = _dbContext.Branch.Remove(branch);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Branch>> GetBranchesByCompanyId(int companyId)
    {
        return await _dbContext.Branch
            .Include(x => x.Company)
            .Where(a => a.CompanyId == companyId && a.IsActive == true)
            .ToListAsync();
    }
}