using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.CityViewModels;
using App.Wiz.Common.ServiceViewModels.CountryViewModels;
using App.Wiz.Domain.Repositories.CityRepository;
using App.Wiz.Domain.ServiceDtos.CityDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.CityServices;

public class CityService : ICityService
{
    private readonly ICityRepository _repository;
    public CityService(ICityRepository repository)
    {
        _repository = repository;
    }
    public async Task<ServiceResponse> CreateCity(CreateCityDto cityDto)
    {
        City city = new()
        {
            CityCode = cityDto.CityCode,
            CityName = cityDto.CityName,
            CountryId = cityDto.CountryId,
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow
        };
        _ = await _repository.AddAsync(city);
        return ServiceResponse.Success(Constants.AddSuccessful);

    }
    public async Task<ServiceResponse> UpdateCity(UpdateCityDto updateCityDto)
    {

        City? city = await _repository.GetAsync(x => x.ID == updateCityDto.Id);
        if (city is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        city.CityCode = updateCityDto.CityCode;
        city.CityName = updateCityDto.CityName;
        city.CountryId = updateCityDto.CountryId;
        city.ModifiedBy = Global.Username;
        city.ModifiedDate = DateTime.UtcNow;

        await _repository.UpdateAsync(city);
        return ServiceResponse.Success(Constants.UpdateSuccessful);

    }
    public async Task<ServiceResponse> GetCity(int Id)
    {
        City? city = await _repository.GetAsync(x => x.ID == Id);
        if (city is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        CityViewModel cityViewModel = new()
        {
            CityCode = city.CityCode,
            CityName = city.CityName,
            Id = city.ID,
            Country = new CountryViewModel()
            {
                Id = city.Country?.ID ?? 0,
                CountryCode = city.Country?.CountryCode,
                CountryName = city.Country?.CountryName
            }
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, cityViewModel);

    }
    public async Task<ServiceResponse> GetAllCities()
    {
        List<CityViewModel> cityViewModels = new();
        List<City> cities = await _repository.GetCity();
        if (cities is not null)
        {
            foreach (City item in cities)
            {

                CityViewModel cityViewModel = new()
                {
                    CityCode = item.CityCode,
                    CityName = item.CityName,
                    Country = new CountryViewModel()
                    {
                        Id = item.Country?.ID ?? 0,
                        CountryCode = item.Country?.CountryCode,
                        CountryName = item.Country?.CountryName
                    },
                    Id = item.ID
                };
                cityViewModels.Add(cityViewModel);
            }
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, cityViewModels);
    }
    public async Task<ServiceResponse> DeleteCity(int id)
    {
        City? city = await _repository.GetCity(id);
        if (city is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }

        await _repository.DeleteAsync(city);
        return ServiceResponse.Success(Constants.DeleteSuccessful);

    }
}
