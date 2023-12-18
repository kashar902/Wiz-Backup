using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.TemplatesRepositories;

public class TemplateFieldsRepository : Repository<TemplateField>, ITemplateFieldsRepository
{
    public TemplateFieldsRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
}