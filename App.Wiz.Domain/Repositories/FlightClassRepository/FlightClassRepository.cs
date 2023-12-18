using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Wiz.Domain.Repositories.FlightClassRepository;

public class FlightClassRepository : Repository<FlightClasses>, IFlightClassRepository
{
    public FlightClassRepository(CatalystWizDbContext context)
        : base(context)
    {

    }

    public async Task<FlightClasses?> GetAsync(int id)
    {
        return await _dbContext.FlightClass.Include(x => x.FlightClassCategory).FirstOrDefaultAsync(x => x.ID == id);
    }
}
