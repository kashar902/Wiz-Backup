using App.Wiz.Application.Profiles.CountryProfiles;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.CountryViewModels;
using App.Wiz.Domain.Repositories.CountryRepository;
using App.Wiz.Domain.ServiceDtos.CountryDto;
using App.Wiz.Infrastructure.Entities;
using static App.Wiz.Common.Messages.Constants;

namespace App.Wiz.Application.Services.CountryServices;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ServiceResponse> GetCountry(int id)
    {
        Country? country = await _countryRepository.GetAsync(x => x.ID == id);

        return
            country is null
            ? ServiceResponse.Failure(NotFound)
            : ServiceResponse.Success(LoadDataSuccess, CountryProfile.PrepareToCountryViewModel(country));
    }

    public async Task<ServiceResponse> GetAllCountries()
    {
        IList<Country> countries = await _countryRepository.GetAllAsync();
        List<CountryViewModel> response = new();
        foreach (Country country in countries)
        {
            response.Add(CountryProfile.PrepareToCountryViewModel(country));
        }
        return ServiceResponse.Success(LoadDataSuccess, response);
    }

    public async Task<ServiceResponse> AddAsync(CreateCountryDto model)
    {
        Country entity = CountryProfile.PrepareToCountry(model);
        if (entity is null)
        {
            return ServiceResponse.Failure(IsNullValue);
        }

        _ = await _countryRepository.AddAsync(entity);
        return ServiceResponse.Success(AddSuccessful);
    }

    public async Task<ServiceResponse> UpdateAsync(UpdateCountryDto updateCountryDto)
    {
        Country? country = await _countryRepository.GetAsync(x => x.ID == updateCountryDto.Id);
        if (country is null)
        {
            return ServiceResponse.Failure(IsNullValue);
        }
        Country entity = CountryProfile.PrepareToCountry(updateCountryDto, country);
        await _countryRepository.UpdateAsync(entity);
        return ServiceResponse.Success(UpdateSuccessful);
    }

    public async Task<ServiceResponse> DeleteAsync(int countryId)
    {
        Country? country =
            await _countryRepository.GetAsync(x => x.ID == countryId);
        if (country is null)
        {
            return ServiceResponse.Failure(IsNullValue);
        }
        await _countryRepository.DeleteAsync(country);
        return ServiceResponse.Success(UpdateSuccessful);
    }
}
