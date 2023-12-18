using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.BudgetPeriodRepository;

public class BudgetPeriodRepository : Repository<AccAssignBranch>, IBudgetPeriodRepository
{
    public BudgetPeriodRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }
}