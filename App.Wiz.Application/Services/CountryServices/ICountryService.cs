using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.CountryDto;

namespace App.Wiz.Application.Services.CountryServices;

public interface ICountryService
{
    Task<ServiceResponse> AddAsync(CreateCountryDto model);
    Task<ServiceResponse> DeleteAsync(int countryId);
    Task<ServiceResponse> GetAllCountries();
    Task<ServiceResponse> GetCountry(int id);
    Task<ServiceResponse> UpdateAsync(UpdateCountryDto updateCountryDto);
}
