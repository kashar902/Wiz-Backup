using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.FieldTypeRepository;

public class FieldTypeRepository : Repository<FieldType>, IFieldTypeRepository
{
    public FieldTypeRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
}
