using App.Wiz.Common.Enums;
using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.TemplatesRepositories;

public class TemplateRepository : Repository<Template>, ITemplateRepository
{
    public TemplateRepository(CatalystWizDbContext context) : base(context)
    {

    }

    public async Task<Template?> GetById(int templateId, int templateTypeId)
    {
        return await _dbContext
                .Templates
                .Where(x => 
                    x.TemplateTypeId == templateTypeId
                    && x.ID == templateId)
                .Include(x => x.TemplateType)!
                .Include(x => x.TemplateFields)!
                .ThenInclude(x => x.ChargeField)
                .Include(x => x.TemplateFields)!
                .ThenInclude(x => x.FormulaBuilder)
                .FirstOrDefaultAsync();
    }

    public async Task<Template?> GetById(int id)
    {
        return await _dbContext
                .Templates
                .Where(x => x.ID == id)
                .Include(x => x.TemplateType)!
                .Include(x => x.TemplateFields)!
                .ThenInclude(x => x.ChargeField)
                .Include(x => x.TemplateFields)!
                .ThenInclude(x => x.FormulaBuilder)
                .FirstOrDefaultAsync();
    }
}