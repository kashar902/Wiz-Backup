using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.CreditTermRepository;

public class CreditTermRepository : Repository<CreditTerm>, ICreditTermRepository
{
    public CreditTermRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }
}