using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.ChargeTypeRepository;

public class ChargeTypeRepository : Repository<ChargeType>, IChargeTypeRepository
{
    public ChargeTypeRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
}
