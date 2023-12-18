using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.CityTaxService
{
	public interface ICityTaxService
	{
		Task<CityTax> AddCityTax(CityTax cityTax);
		Task<int> DeleteCityTax(CityTax cityTax);
		Task<List<CityTax>> GetAllCityTaxes();
		Task<CityTax?> GetCityTax(int Id);
		Task<int> UpdateCityTax(CityTax cityTax);
	}
}
