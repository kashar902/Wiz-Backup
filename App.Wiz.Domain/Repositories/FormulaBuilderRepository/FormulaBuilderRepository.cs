using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.FormulaBuilderRepository;

public class FormulaBuilderRepository : Repository<FormulaBuilder>, IFormulaBuilderRepository
{
    public FormulaBuilderRepository(CatalystWizDbContext context)
        : base(context)
    {

    }

}
