using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.CompanyRepository;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<Company> GetAsync(int id)
    {
        return await _dbContext.Companies
            .Include(x => x.GroupOfCompanies)
            .Include(x => x.Currency)
            .FirstOrDefaultAsync(x => x.ID == id);
    }
    public async Task<List<Company>> GetAllCompaniesAsync()
    {
        return await _dbContext.Companies
            .Include(x => x.GroupOfCompanies)
            .Include(x => x.Currency)
            .ToListAsync();
    }
    public async Task<List<Company>> GetAllActiveCompanies()
    {
        return await _dbContext.Companies.Where(x => x.Active)
            .Include(x => x.GroupOfCompanies)
            .Include(x => x.Currency).ToListAsync();
    }
}