using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.CityRepository;

public interface ICityRepository : IRepository<City>
{
    Task<List<City>> GetCity();
    Task<City?> GetCity(int Id);
}
