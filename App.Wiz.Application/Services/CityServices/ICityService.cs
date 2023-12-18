using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.CityDto;

namespace App.Wiz.Application.Services.CityServices;

public interface ICityService
{
    Task<ServiceResponse> CreateCity(CreateCityDto cityDto);
    Task<ServiceResponse> UpdateCity(UpdateCityDto updateCityDto);
    Task<ServiceResponse> GetCity(int Id);
    Task<ServiceResponse> GetAllCities();
    Task<ServiceResponse> DeleteCity(int id);
}
