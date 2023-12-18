using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.CountryRepository;

public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }
}