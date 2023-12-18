using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.ApplicationDbContext;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.VehicleRepository;

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(CatalystWizDbContext context)
        : base(context)
    {

    }
}
