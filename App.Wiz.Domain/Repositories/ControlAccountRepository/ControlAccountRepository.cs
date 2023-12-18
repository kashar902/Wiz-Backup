using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.ControlAccountRepository;

public class ControlAccountRepository : Repository<AccControlAccount>, IControlAccountRepository
{
    public ControlAccountRepository(CatalystWizDbContext dbcontext)
        : base(dbcontext)
    {

    }

    public async Task<AccControlAccount?> GetAsync(string id)
    {
        return await _dbContext.AccControlAccounts.
            Include(x => x.SuperType)
            .FirstOrDefaultAsync(x => x.ID == Guid.Parse(id));
    }
    public async Task<List<string>> GetAllAccountCodeAsync()
    {
        return await _dbContext.AccControlAccounts.
            Select(x => x.AccountCode)
            .ToListAsync();
    }
    public async Task<AccControlAccount?> GetControlAccountByCodeAsync(string accountCode)
    {
        return await _dbContext
            .AccControlAccounts
            .FirstOrDefaultAsync(x => x.AccountCode == "1" + accountCode);
    }
}
