using App.Wiz.Common.ServiceViewModels.CountryViewModels;

namespace App.Wiz.Common.ServiceViewModels.CityViewModels;

public class CityViewModel
{
    public int Id { get; set; }
    public string? CityName { get; set; }
    public string? CityCode { get; set; }
    public CountryViewModel? Country { get; set; }
}
