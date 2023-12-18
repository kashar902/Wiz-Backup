using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.FlightClassCategoryDto;
using App.Wiz.Domain.ServiceDtos.FlightClassDto;

namespace App.Wiz.Application.Services.FlightClassServices;

public interface IFlightClassService
{
    Task<ServiceResponse> Create(CreateFlightClassDto dto);
    Task<ServiceResponse> Create(CreateFlightClassCategoryDto dto);
    Task<ServiceResponse> Delete(int id);
    Task<ServiceResponse> DeleteFlightClassCategory(int id);
    Task<ServiceResponse> Get();
    Task<ServiceResponse> GetById(int id);
    Task<ServiceResponse> GetFlightClassCategories();
    Task<ServiceResponse> GetFlightClassCategoryById(int id);
    Task<ServiceResponse> Update(UpdateFlightClassDto dto);
    Task<ServiceResponse> Update(UpdateFlightClassCategoryDto dto);
}
