using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.CountryViewModels;
using App.Wiz.Domain.ServiceDtos.CountryDto;

namespace App.Wiz.Application.Profiles.CountryProfiles;

public static class CountryProfile
{
    public static CountryViewModel PrepareToCountryViewModel(Infrastructure.Entities.Country country)
    {
        return new()
        {
            CountryCode = country.CountryCode,
            Id = country.ID,
            CountryName = country.CountryName
        };
    }

    public static Infrastructure.Entities.Country PrepareToCountry(CreateCountryDto country)
    {
        return new()
        {
            CountryCode = country.CountryCode,
            CountryName = country.CountryName,
            CreatedBy = Global.Username,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow
        };
    }
    public static Infrastructure.Entities.Country PrepareToCountry(UpdateCountryDto updateCountryDto, Infrastructure.Entities.Country country)
    {
        country.CountryName = updateCountryDto.CountryName;
        country.CountryCode = updateCountryDto.CountryCode;
        country.ModifiedBy = Global.Username;
        country.ModifiedDate = DateTime.UtcNow;
        return country;
    }
}
