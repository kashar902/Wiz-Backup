using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Wiz.Domain.Repositories.FormulaChargeFieldRepository;

public class FormulaChargeFieldRepository : Repository<FormulaChargeFields>, IFormulaChargeFieldRepository
{
    public FormulaChargeFieldRepository(CatalystWizDbContext context) : base(context)
    {
        
    }
}
