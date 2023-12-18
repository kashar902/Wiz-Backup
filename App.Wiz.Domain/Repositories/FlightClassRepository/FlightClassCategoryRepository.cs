using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.FlightClassRepository;

public class FlightClassCategoryRepository : Repository<FlightClassCategory>, IFlightClassCategoryRepository
{
    public FlightClassCategoryRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
}
