using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.SubsidaryAccountRepository
{
    public interface ISubsidaryAccountRepository : IRepository<AccSubsidaryAccount>
    {
        Task<bool> CheckIsParentAsync(string id);
        Task<AccSubsidaryAccount?> Get(Guid guid);
        Task<List<AccSubsidaryAccount>> GetAll();
        Task<List<AccBudgetPeriod>> GetAllBudegetPeriod();
        Task<List<AccSubsidaryAccount>> GetAllByControlAccount(string id);
        Task<AccBudgetPeriod?> GetBudegetPeriod(int id);
        Task<AccSubsidaryAccount?> GetSubsidaryAccountByCode(string accountCode);
        Task<int> RemoveAsync(AccSubsidaryAccount entity);
    }
}