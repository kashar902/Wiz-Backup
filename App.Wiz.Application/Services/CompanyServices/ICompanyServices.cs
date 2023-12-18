using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.CompanyDto;

namespace App.Wiz.Application.Services.CompanyServices;

public interface ICompanyServices
{
    Task<ServiceResponse> GetAllCompanies(bool active);
    Task<ServiceResponse> GetSingleCompany(int id);
    Task<ServiceResponse> CreateCompany(CreateCompanyDto createCompanyDto);
    Task<ServiceResponse> UpdateCompany(UpdateCompanyDto updateCompanyDto);
    Task<ServiceResponse> DeleteCompany(int id);
}
