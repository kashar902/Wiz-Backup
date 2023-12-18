using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.TemplatesRepositories;

public interface ITemplateRepository : IRepository<Template>
{
    Task<Template?> GetById(int id);
    Task<Template?> GetById(int templateId, int templateTypeId);
}