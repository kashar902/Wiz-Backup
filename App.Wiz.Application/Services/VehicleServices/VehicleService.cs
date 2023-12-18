using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.VehicleViewModels;
using App.Wiz.Domain.Repositories.VehicleRepository;
using App.Wiz.Domain.ServiceDtos.VehicleDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.VehicleServices;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;
    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse> CreateVehicle(CreateVehicleDto createVehicleDto)
    {
        Vehicle vehicle = new()
        {
            Title = createVehicleDto.Title,
            Make = createVehicleDto.Make,
            Model = createVehicleDto.Model,
            RegistrationNo = createVehicleDto.RegistrationNo,
            Description = createVehicleDto.Description,
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow
        };
        _ = await _repository.AddAsync(vehicle);
        return ServiceResponse.Success(Constants.AddSuccessful);
    }

    public async Task<ServiceResponse> DeleteVehicle(int id)
    {
        Vehicle? vehicle = await _repository.GetAsync(x => x.ID == id);
        if (vehicle is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        await _repository.DeleteAsync(vehicle);
        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }

    public async Task<ServiceResponse> GetAllVehicles()
    {
        List<VehicleViewModel> vehicleViewModels = new();
        IList<Vehicle> vehicles = await _repository.GetAllAsync();

        foreach (Vehicle vehicle in vehicles)
        {
            VehicleViewModel vehicleViewModel = new()
            {
                ID = vehicle.ID,
                Title = vehicle.Title,
                Make = vehicle.Make,
                Model = vehicle.Model,
                RegistrationNo = vehicle.RegistrationNo,
                Description = vehicle.Description
            };
            vehicleViewModels.Add(vehicleViewModel);
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, vehicleViewModels);
    }

    public async Task<ServiceResponse> GetVehicle(int id)
    {
        Vehicle? vehicle = await _repository.GetAsync(x => x.ID == id);
        if (vehicle is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        VehicleViewModel vehicleViewModel = new()
        {
            Title = vehicle.Title,
            Make = vehicle.Make,
            Model = vehicle.Model,
            RegistrationNo = vehicle.RegistrationNo,
            Description = vehicle.Description,
            ID = vehicle.ID,
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, vehicleViewModel);
    }

    public async Task<ServiceResponse> UpdateVehicle(UpdateVehicleDto updateVehicleDto)
    {
        Vehicle? vehicle = await _repository.GetAsync(x => x.ID == updateVehicleDto.ID);
        if (vehicle is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        vehicle.Title = updateVehicleDto.Title;
        vehicle.Make = updateVehicleDto.Make;
        vehicle.Model = updateVehicleDto.Model;
        vehicle.RegistrationNo = updateVehicleDto.RegistrationNo;
        vehicle.Description = updateVehicleDto.Description;
        vehicle.ModifiedBy = Global.Username;
        vehicle.ModifiedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(vehicle);
        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }
}
