using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.ServiceViewModels.SubsidaryViewModels;
using App.Wiz.Domain.ServiceDtos.SubsidiaryAccountDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.SubsidaryAccountServices;

public interface ISubsidaryAccountService
{
    Task<ServiceResponse> AddAsync(CreateSubsidiaryAccountDto dto);
    Task<ServiceResponse> DeleteAsync(Guid id);
    Task<ServiceResponse> Get(Guid id);
    Task<ServiceResponse> GetAll();
    Task<ServiceResponse> GetAllBudgetPeriod();
    Task<ServiceResponse> GetBudgetPeriod(int id);
    Task<ServiceResponse> GetCustomerSupplierDropDown();
    Task<ServiceResponse> UpdateAsync(UpdateSubsidiaryAccountDto dto);
}