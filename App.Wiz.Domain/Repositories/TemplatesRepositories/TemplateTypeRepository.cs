using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.TemplatesRepositories;

public class TemplateTypeRepository : Repository<TemplateType>, ITemplateTypeRepository
{
    public TemplateTypeRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
}