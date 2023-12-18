using UserAssociates.Business.Dtos.CityTaxDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Business.Dtos.VisaTypeDto;
using UserAssociates.Database.Models;

namespace UserAssociates.Business.Logic.CityBusinessLogic
{
    public interface ICityTaxBusinessLogic
    {
        Task<string> CreateCityTax(CreateCityTaxDto createCityTaxDto);
        Task<string> UpdateCityTax(UpdateCityTaxDto updateCityTaxDto);
        Task<CityTaxViewModel?> GetCityTax(int Id);
        Task<List<CityTax>> GetAllCityTaxes();
        Task<string> DeleteCityTax(int id);
    }
}
