using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.FormulaBuilderDtos;

namespace App.Wiz.Application.Services.FormulaBuilderServices;

public interface IFormulaBuilderService
{
    Task<ServiceResponse> AddAsync(CreateFormulaBuilderDto dto);
    Task<ServiceResponse> DeleteAsync(int id);
    Task<ServiceResponse> GetAsync();
    Task<ServiceResponse> GetAsync(int id);
    Task<ServiceResponse> UpdateAsync(UpdateFormulaBuilderDto dto);
}