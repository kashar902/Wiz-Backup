using App.Wiz.Application.Profiles.CountryProfiles;
using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.CityViewModels;
using App.Wiz.Domain.ServiceDtos.CityDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Profiles.CityProfiles;

public class CityProfile
{
    public static CityViewModel PrepareToViewModel(City entity)
    {
        return new CityViewModel
        {
            Id = entity.ID,
            CityName = entity.CityName,
            CityCode = entity.CityCode,
            Country = CountryProfile.PrepareToCountryViewModel(entity.Country!),
        };
    }

    public static City PrepareToEntity(CreateCityDto dto)
    {
        return new City
        {
            CreatedBy = Global.Username,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow,
            CityName = dto.CityName,
            CityCode = dto.CityCode,
            CountryId = dto.CountryId,
        };
    }

    public static City PrepareToEntity(UpdateCityDto dto, City entity)
    {
        entity.ModifiedBy = Global.Username;
        entity.ModifiedDate = DateTime.UtcNow;
        entity.CityName = dto.CityName;
        entity.CityCode = dto.CityCode;
        entity.CountryId = dto.CountryId;
        return entity;
    }
}
