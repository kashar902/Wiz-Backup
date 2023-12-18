using Commons.Helper;
using Commons.Messages;
using UserAssociates.Business.Dtos.CityTaxDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.CityTaxService;

namespace UserAssociates.Business.Logic.CityBusinessLogic
{
    public class CityTaxBusinessLogic : ICityTaxBusinessLogic
    {
        private readonly ICityTaxService _cityTaxService;
        public CityTaxBusinessLogic(ICityTaxService cityTaxService)
        {
            _cityTaxService = cityTaxService;
        }

        public async Task<string> CreateCityTax(CreateCityTaxDto createCityTaxDto)
        {
            try
            {
                CityTax cityTax = new()
                {
                    Code = createCityTaxDto.Code,
                    Title = createCityTaxDto.Title,
                    Amount = createCityTaxDto.Amount,
                    DebitAccount = createCityTaxDto.DebitAccount,
                    CreditAccount = createCityTaxDto.CreditAccount,
                    CreatedBy = Global.Username,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = Global.Username,
                    ModifiedDate = DateTime.UtcNow
                };

                CityTax value = await _cityTaxService.AddCityTax(cityTax);
                return Constants.CityTax.CreateSuccessful;
            }
            catch (CustomException)
            {
                throw;
            }

        }

        public async Task<string> DeleteCityTax(int id)
        {
            try
            {
                CityTax? cityTax = await _cityTaxService.GetCityTax(id);
                if (cityTax is null)
                {
                    return Constants.NotFound;
                }

                int successCount = await _cityTaxService.DeleteCityTax(cityTax);
                return successCount != 0 ? Constants.CityTax.DeleteSuccessful : Constants.Error;
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<List<CityTax>> GetAllCityTaxes()
        {

            try
            {
                return await _cityTaxService.GetAllCityTaxes();
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<CityTaxViewModel?> GetCityTax(int Id)
        {
            try
            {
                CityTax? cityTax = await _cityTaxService.GetCityTax(Id);
                if (cityTax is null)
                {
                    return null;
                }

                CityTaxViewModel cityTaxViewModel = new()
                {
                    Code = cityTax.Code,
                    Title = cityTax.Title,
                    Amount = cityTax.Amount,
                    DebitAccount = cityTax.DebitAccount,
                    CreditAccount = cityTax.CreditAccount,
                    CreatedBy = cityTax.CreatedBy,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = cityTax.CreatedBy,
                    ModifiedDate = DateTime.UtcNow,
                    ID = cityTax.ID,
                };
                return cityTaxViewModel;
            }
            catch (CustomException)
            {
                throw;
            }
        }

        public async Task<string> UpdateCityTax(UpdateCityTaxDto updateCityTaxDto)
        {

            try
            {
                CityTax? cityTax = await _cityTaxService.GetCityTax(updateCityTaxDto.ID);
                if (cityTax is null)
                {
                    return Constants.NotFound;
                }

                cityTax.Code = updateCityTaxDto.Code;
                cityTax.Title = updateCityTaxDto.Title;
                cityTax.Amount = updateCityTaxDto.Amount;
                cityTax.DebitAccount = updateCityTaxDto.DebitAccount;
                cityTax.CreditAccount = updateCityTaxDto.CreditAccount;
                cityTax.ModifiedBy = Global.Username;
                cityTax.ModifiedDate = DateTime.UtcNow;

                int successCount = await _cityTaxService.UpdateCityTax(cityTax);
                return successCount != 0 ? Constants.CityTax.UpdateSuccessful : Constants.Error;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}
