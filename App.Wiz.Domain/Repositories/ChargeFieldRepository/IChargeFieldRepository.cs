using App.Wiz.Domain.Repositories.GenericRepository;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.Repositories.ChargeFieldRepository;

public interface IChargeFieldRepository : IRepository<ChargeField>
{
    Task<ChargeField?> GetAsync(int id);
}