using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.ControlAccountRepository
{
    public interface IControlAccountRepository : IRepository<AccControlAccount>
    {
        Task<List<string>> GetAllAccountCodeAsync();
        Task<AccControlAccount?> GetAsync(string id);
        Task<AccControlAccount?> GetControlAccountByCodeAsync(string accountCode);
    }
}