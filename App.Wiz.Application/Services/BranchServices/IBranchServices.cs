using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.AgencyDto;

namespace App.Wiz.Application.Services.BranchServices;

public interface IBranchServices
{
    Task<ServiceResponse> GetAllAgencies();
    Task<ServiceResponse> GetSingleAgency(int id);
    Task<ServiceResponse> AddAgency(CreateAgencyDto createAgencyDto);
    Task<ServiceResponse> UpdateActivestatus(UpdateAgencyDto agencyDto);
    Task<ServiceResponse> GetAgenciesByCompanyId(int companyId);
    Task<ServiceResponse> GetAgenciesByUserId(int userId);
    Task<ServiceResponse> DeleteAgency(int id);
}
