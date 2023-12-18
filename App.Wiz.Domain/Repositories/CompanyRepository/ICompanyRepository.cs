using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.CompanyRepository;

public interface ICompanyRepository : IRepository<Company>
{
    Task<List<Company>> GetAllActiveCompanies();
    Task<List<Company>> GetAllCompaniesAsync();
    Task<Company> GetAsync(int id);
}
