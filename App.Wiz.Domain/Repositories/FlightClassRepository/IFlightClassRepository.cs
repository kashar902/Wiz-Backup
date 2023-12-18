using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.FlightClassRepository;

public interface IFlightClassRepository : IRepository<FlightClasses>
{
    Task<FlightClasses?> GetAsync(int id);
}