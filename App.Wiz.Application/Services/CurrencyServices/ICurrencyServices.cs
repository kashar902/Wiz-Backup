using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Domain.ServiceDtos.CurrencyDto;

namespace App.Wiz.Application.Services.CurrencyServices;

public interface ICurrencyServices
{
    Task<ServiceResponse> CreateCurrency(CreateCurrencyDto currencyDto);
    Task<ServiceResponse> UpdateCurrency(UpdateCurrencyDto currencyDto);
    Task<ServiceResponse> GetCurrency(int Id);
    Task<ServiceResponse> DeleteCurrency(int id);
    Task<ServiceResponse> GetAllCurrencies(bool active);
}
