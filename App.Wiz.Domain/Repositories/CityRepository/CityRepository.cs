using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.CityRepository;

public class CityRepository : Repository<City>, ICityRepository
{
    public CityRepository(CatalystWizDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<City?> GetCity(int Id)
    {
        return await _dbContext.Cities
            .Include(x => x.Country)
            .FirstOrDefaultAsync(x => x.ID == Id);
    }
    public async Task<List<City>> GetCity()
    {
        return await _dbContext.Cities
            .Include(x => x.Country)
            .ToListAsync();
    }
}