using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.SuperTypeRepository;

public class SuperTypeRepository : Repository<AccSuperType>, ISuperTypeRepository
{
    public SuperTypeRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
}
