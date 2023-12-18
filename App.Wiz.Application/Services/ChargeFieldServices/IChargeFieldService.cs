using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.ChargeFieldDto;

namespace App.Wiz.Application.Services.ChargeFieldServices
{
    public interface IChargeFieldService
    {
        Task<ServiceResponse> Add(CreateChargeFieldDto dto);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Get();
        Task<ServiceResponse> GetChargeField();
        Task<ServiceResponse> GetChargeFieldFormData();
        Task<ServiceResponse> Update(UpdateChargeFieldDto dto);
    }
}