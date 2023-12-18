using App.Wiz.Application.Profiles.FlightClassProfiles;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.FlightClassesViewModels;
using App.Wiz.Domain.Repositories.FlightClassRepository;
using App.Wiz.Domain.ServiceDtos.FlightClassCategoryDto;
using App.Wiz.Domain.ServiceDtos.FlightClassDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.FlightClassServices;
public class FlightClassService : IFlightClassService
{
    private readonly IFlightClassCategoryRepository _flightClassCategoryRepository;
    private readonly IFlightClassRepository _flightClassRepository;

    public FlightClassService(IFlightClassCategoryRepository flightClassCategoryRepository, IFlightClassRepository flightClassRepository)
    {
        _flightClassCategoryRepository = flightClassCategoryRepository;
        _flightClassRepository = flightClassRepository;
    }
    public async Task<ServiceResponse> Get()
    {
        IList<FlightClasses> flightClasses = await _flightClassRepository.GetAllAsync(x => x.FlightClassCategory!);
        List<FlightClassViewModel> flightClassViews = new();


        foreach (FlightClasses flightClass in flightClasses)
        {
            flightClassViews.Add(FlightClassProfile.PrepareViewModel(flightClass));
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, flightClassViews);
    }
    public async Task<ServiceResponse> GetById(int id)
    {
        try
        {
            FlightClasses? flightClass = await _flightClassRepository.GetAsync(id);
            if (flightClass is null)
            {
                return ServiceResponse.Failure(Constants.NotExist);
            }
            FlightClassViewModel flightClassViewModel = FlightClassProfile.PrepareViewModel(flightClass);
            return ServiceResponse.Success(Constants.LoadDataSuccess, flightClassViewModel);
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<ServiceResponse> Delete(int id)
    {
        try
        {
            FlightClasses? flightClass = await _flightClassRepository.GetAsync(x => x.ID == id);
            if (flightClass is null)
            {
                return ServiceResponse.Failure(Constants.NotExist);
            }

            await _flightClassRepository.DeleteAsync(flightClass);
            return ServiceResponse.Success(Constants.DeleteSuccessful);

        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<ServiceResponse> Update(UpdateFlightClassDto dto)
    {
        // Query the database to get the International and Domestic category IDs
        FlightClasses? flightClass = await _flightClassRepository.GetAsync(x => x.ID == dto.ID);
        if (flightClass is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        if (flightClass.Title?.ToLower() == dto.Title?.ToLower() &&
            flightClass.FlightClassCategoryId == dto.FlightClassCategoryId &&
            flightClass.Description?.ToLower() == dto.Description?.ToLower())
        {
            return ServiceResponse.Failure(Constants.AlreadyExist);
        }

        await _flightClassRepository.UpdateAsync(dto.PrepareToEntity(flightClass));
        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }
    public async Task<ServiceResponse> Create(CreateFlightClassDto dto)
    {
        _ = await _flightClassRepository.AddAsync(dto.PrepareToEntity());
        return ServiceResponse.Success(Constants.AddSuccessful);
    }
    public async Task<ServiceResponse> GetFlightClassCategories()
    {
        IList<FlightClassCategory> flightClasses = await _flightClassCategoryRepository.GetAllAsync();
        List<FlightClassCategoryViewModel> flightClassViews = new();


        foreach (FlightClassCategory flightClass in flightClasses)
        {
            flightClassViews.Add(FlightClassProfile.PrepareViewModel(flightClass));
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, flightClassViews);
    }
    public async Task<ServiceResponse> GetFlightClassCategoryById(int id)
    {
        FlightClassCategory? flightClass = await _flightClassCategoryRepository.GetAsync(x => x.ID == id);
        if (flightClass is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }
        FlightClassCategoryViewModel flightClassViewModel = FlightClassProfile.PrepareViewModel(flightClass);
        return ServiceResponse.Success(Constants.LoadDataSuccess, flightClassViewModel);
    }
    public async Task<ServiceResponse> DeleteFlightClassCategory(int id)
    {
        FlightClassCategory? flightClass = await _flightClassCategoryRepository.GetAsync(x => x.ID == id);
        if (flightClass is null)
        {
            return ServiceResponse.Failure(Constants.NotExist);
        }

        await _flightClassCategoryRepository.DeleteAsync(flightClass);
        return ServiceResponse.Success(Constants.DeleteSuccessful);
    }
    public async Task<ServiceResponse> Update(UpdateFlightClassCategoryDto dto)
    {
        // Query the database to get the International and Domestic category IDs
        FlightClassCategory? flightClass = await _flightClassCategoryRepository.GetAsync(x => x.ID == dto.Id);
        if (flightClass is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        await _flightClassCategoryRepository.UpdateAsync(dto.PrepareToEntity(flightClass));
        return ServiceResponse.Success(Constants.UpdateSuccessful);
    }
    public async Task<ServiceResponse> Create(CreateFlightClassCategoryDto dto)
    {
        _ = await _flightClassCategoryRepository.AddAsync(dto.PrepareToEntity());
        return ServiceResponse.Success(Constants.AddSuccessful);
    }
}
