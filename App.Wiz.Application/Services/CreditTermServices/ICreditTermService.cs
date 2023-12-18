using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.CreditTermDto;

namespace App.Wiz.Application.Services.CreditTermServices;

public interface ICreditTermService
{
    Task<ServiceResponse> CreateCreditTerm(CreateCreditTermDto creditTermDto);
    Task<ServiceResponse> UpdateCreditTerm(UpdateCreditTermDto updateCreditTermDto);
    Task<ServiceResponse> GetCreditTerm(int Id);
    Task<ServiceResponse> DeleteCreditTerm(int id);
    Task<ServiceResponse> GetAllCreditTerms();
}
