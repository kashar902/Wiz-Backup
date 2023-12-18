using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.ChargeFieldService;

public interface IChargeFieldService
{
    Task<List<ChargeField>> Get();
    Task<ChargeField?> Get(int id);
    Task<int> Delete(ChargeField entity);
    Task<ChargeField> Add(ChargeField entity);
    Task<int> Update(ChargeField chargeField);
}
