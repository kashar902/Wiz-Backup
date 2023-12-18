using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.SubsidaryAccountRepository;

public class SubsidaryAccountRepository : Repository<AccSubsidaryAccount>, ISubsidaryAccountRepository
{
    public SubsidaryAccountRepository(CatalystWizDbContext dbContext)
        : base(dbContext)
    {

    }

    public async Task<int> RemoveAsync(AccSubsidaryAccount entity)
    {
        _ = _dbContext.AccSubsidaryAccount.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<AccSubsidaryAccount>> GetAll()
    {
        return await _dbContext
             .AccSubsidaryAccount
             .Include(m => m.SuperType)
             .Include(x => x.ControlAccount)
             .Include(x => x.Currency)
             .ToListAsync();
    }
    public async Task<List<AccSubsidaryAccount>> GetAllByControlAccount(string id)
    {
        return await _dbContext
             .AccSubsidaryAccount
             .Include(m => m.SuperType)
             .Where(x => x.ControlAccountId == Guid.Parse(id))
             .ToListAsync();
    }
    public async Task<bool> CheckIsParentAsync(string id)
    {
        return await _dbContext
             .AccSubsidaryAccount
             .Where(x => x.ControlAccountId == Guid.Parse(id))
             .AnyAsync();
    }
    public async Task<AccSubsidaryAccount?> Get(Guid guid)
    {
        return await _dbContext
             .AccSubsidaryAccount.Where(x => x.ID == guid)
           .Include(m => m.SuperType)
             .Include(x => x.ControlAccount)
             .Include(x => x.Currency)
             .FirstOrDefaultAsync();
    }
    public async Task<AccSubsidaryAccount?> GetSubsidaryAccountByCode(string accountCode)
    {
        return await _dbContext
             .AccSubsidaryAccount
             .Where(x => x.AccountCode == "1" + accountCode)
             .FirstOrDefaultAsync();
    }
    public async Task<List<AccBudgetPeriod>> GetAllBudegetPeriod()
    {
        return await _dbContext
             .AccBudgetPeriod
             .ToListAsync();
    }
    public async Task<AccBudgetPeriod?> GetBudegetPeriod(int id)
    {
        return await _dbContext
             .AccBudgetPeriod
             .FirstOrDefaultAsync(x => x.ID == id);
    }


}
