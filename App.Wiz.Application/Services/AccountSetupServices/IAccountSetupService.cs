using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.AccountSetupDto;

namespace App.Wiz.Application.Services.AccountSetupServices
{
    public interface IAccountSetupService
    {
        Task<ServiceResponse> Add(CreateAccountDto dto);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Get();
        Task<ServiceResponse> GetAccountSetupForm();
        Task<ServiceResponse> Update(UpdateAccountDto dto);
    }
}