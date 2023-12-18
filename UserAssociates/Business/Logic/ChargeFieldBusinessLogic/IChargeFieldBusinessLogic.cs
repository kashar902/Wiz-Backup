using UserAssociates.Business.Dtos.ChargeFieldDto;
using UserAssociates.Business.Viewmodels;

namespace UserAssociates.Business.Logic.ChargeFieldBusinessLogic;

public interface IChargeFieldBusinessLogic
{
    Task<ChargeFieldViewModel> Create(CreateChargeFieldDto dto);
    Task<List<ChargeFieldViewModel>?> GetAll();
    Task<ChargeFieldViewModel?> GetById(int id);
    Task<List<ChargeFieldViewModel>?> Delete(int id);
    Task<List<ChargeFieldViewModel>?> Update(UpdateChargeFieldDto chargeField);
}
