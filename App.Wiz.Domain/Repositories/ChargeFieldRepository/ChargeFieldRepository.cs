using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.ChargeFieldRepository;

public class ChargeFieldRepository : Repository<ChargeField>, IChargeFieldRepository
{

    public ChargeFieldRepository(CatalystWizDbContext context) : base(context)
    {


    }

    public async Task<ChargeField?> GetAsync(int id)
    {
        return await _dbContext.ChargeField
            .Include(x => x.ChargeType)
            .Include(x => x.FieldType)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
}
