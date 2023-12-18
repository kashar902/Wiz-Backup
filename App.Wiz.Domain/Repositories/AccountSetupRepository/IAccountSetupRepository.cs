using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.AccountSetupRepository;

public interface IAccountSetupRepository : IRepository<AccountSetup>
{
    Task<bool> CheckControlAccountAsync(string controlAccountId);
    Task<bool> ChecksubsidaryAccountAsync(string controlAccountId);
}