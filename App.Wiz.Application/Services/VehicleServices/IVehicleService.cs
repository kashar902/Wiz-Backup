using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.VehicleDto;

namespace App.Wiz.Application.Services.VehicleServices;

public interface IVehicleService
{
    Task<ServiceResponse> CreateVehicle(CreateVehicleDto createVehicleDto);
    Task<ServiceResponse> DeleteVehicle(int id);
    Task<ServiceResponse> GetAllVehicles();
    Task<ServiceResponse> GetVehicle(int id);
    Task<ServiceResponse> UpdateVehicle(UpdateVehicleDto updateVehicleDto);
}
