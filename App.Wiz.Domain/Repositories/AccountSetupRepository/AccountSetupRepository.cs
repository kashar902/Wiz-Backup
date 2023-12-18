using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.AccountSetupRepository;

public class AccountSetupRepository : Repository<AccountSetup>, IAccountSetupRepository
{
    public AccountSetupRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckControlAccountAsync(string controlAccountId)
    {
        return await _dbContext.AccountSetup.AnyAsync(x => x.CustomerId == controlAccountId || x.SupplierId == controlAccountId);
    }
    public async Task<bool> ChecksubsidaryAccountAsync(string subsidaryAccountId)
    {
        return await _dbContext.AccountSetup.
            AnyAsync(x => x.BalanceEquity == subsidaryAccountId
            || x.VoidCharge == subsidaryAccountId || x.ExchangeDiff == subsidaryAccountId);
    }
}
