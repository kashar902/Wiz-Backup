using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.BudgetRepository;

public interface IBudgetRepository : IRepository<AccBudget>
{
    Task<List<AccBudget>> GetAsync();
    Task<List<AccBudget>> GetAsync(Guid parentId);
    Task<AccBudget?> GetAsync(int branchId);
    Task RemoveAsync(List<AccBudget> entity);
}
