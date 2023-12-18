using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.ServiceViewModels.ControlAccountViewModels;
using App.Wiz.Domain.ServiceDtos.AccountSetupDto;
using App.Wiz.Domain.ServiceDtos.ControlAccountDto;

namespace App.Wiz.Application.Services.ControlAccountServices
{
    public interface IControlAccountService
    {
        Task<ServiceResponse> AddAsync(CreateControlAccountDto dto);
        Task<ServiceResponse> DeleteAsync(string controlAccountId);
        Task<ServiceResponse> Get();
        Task<ServiceResponse> GetById(string id, bool isControlAccount);
        Task<ServiceResponse> ToggleActiveStatus(string controlAccountId);
        Task<ServiceResponse> UpdateAsync(UpdateControlAccountDto dto);
    }
}