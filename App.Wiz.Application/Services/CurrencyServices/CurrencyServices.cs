using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.Helper;
using App.Wiz.Common.Messages;
using App.Wiz.Common.ServiceViewModels.CurrencyViewModels;
using App.Wiz.Domain.Repositories.CurrencyRepository;
using App.Wiz.Domain.ServiceDtos.CurrencyDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Services.CurrencyServices;

public class CurrencyServices : ICurrencyServices
{
    private readonly ICurrencyRepository _repository;

    public CurrencyServices(ICurrencyRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse> CreateCurrency(CreateCurrencyDto currencyDto)
    {
        Currency currency = new()
        {
            CurrencyCode = currencyDto.CurrencyCode,
            CurrencyName = currencyDto.CurrencyName,
            CurrencySymbol = currencyDto.CurrencySymbol,
            Description = currencyDto.Description,
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            ActivateCurrency = currencyDto.ActivateCurrency,
            DecimalSeparator = currencyDto.DecimalSeparator,
            EffectiveDate = currencyDto.EffectiveDate,
            Precision = currencyDto.Precision,
            ThousandSeparator = currencyDto.ThousandSeparator,
        };

        _ = await _repository.AddAsync(currency);

        return ServiceResponse.Success(Constants.AddSuccessful);
    }

    public async Task<ServiceResponse> UpdateCurrency(UpdateCurrencyDto currencyDto)
    {
        Currency? currency = await _repository.GetAsync(x => x.ID == currencyDto.ID);
        if (currency is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }
        currency.CurrencyCode = currencyDto.CurrencyCode;
        currency.CurrencyName = currencyDto.CurrencyName;
        currency.CurrencySymbol = currencyDto.CurrencySymbol;
        currency.Description = currencyDto.Description;
        currency.ModifiedBy = Global.Username;
        currency.ModifiedDate = DateTime.UtcNow;
        currency.ActivateCurrency = currencyDto.ActivateCurrency;
        currency.DecimalSeparator = currencyDto.DecimalSeparator;
        currency.EffectiveDate = currencyDto.EffectiveDate;
        currency.Precision = currencyDto.Precision;
        currency.ThousandSeparator = currencyDto.ThousandSeparator;

        await _repository.UpdateAsync(currency);
        return ServiceResponse.Success(Constants.UpdateSuccessful);

    }

    public async Task<ServiceResponse> GetCurrency(int Id)
    {
        Currency? currency = await _repository.GetAsync(x => x.ID == Id);
        if (currency is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }
        CurrencyViewModel viewModel = new()
        {
            ID = currency.ID,
            CurrencyCode = currency.CurrencyCode,
            CurrencyName = currency.CurrencyName,
            CurrencySymbol = currency.CurrencySymbol,
            Description = currency.Description,
            ThousandSeparator = currency.ThousandSeparator,
            Precision = currency.Precision,
            EffectiveDate = currency.EffectiveDate.HasValue ? currency.EffectiveDate.Value.AddDays(1).Date : null,
            DecimalSeparator = currency.DecimalSeparator,
            ActivateCurrency = currency.ActivateCurrency,
        };
        return ServiceResponse.Success(Constants.LoadDataSuccess, viewModel);

    }

    public async Task<ServiceResponse> GetAllCurrencies(bool active)
    {
        List<CurrencyViewModel> currencyViewModels = new();
        IList<Currency> currencies = active
            ? await _repository.GetAllAsync(x => x.ActivateCurrency == true)
            : await _repository.GetAllAsync();

        foreach (Currency currency in currencies)
        {
            CurrencyViewModel viewModel = new()
            {
                ID = currency.ID,
                CurrencyCode = currency.CurrencyCode,
                CurrencyName = currency.CurrencyName,
                CurrencySymbol = currency.CurrencySymbol,
                Description = currency.Description,
                ThousandSeparator = currency.ThousandSeparator,
                Precision = currency.Precision,
                EffectiveDate = currency.EffectiveDate,
                DecimalSeparator = currency.DecimalSeparator,
                ActivateCurrency = currency.ActivateCurrency,
            };
            currencyViewModels.Add(viewModel);
        }
        return ServiceResponse.Success(Constants.LoadDataSuccess, currencyViewModels);

    }

    public async Task<ServiceResponse> DeleteCurrency(int id)
    {
        Currency? currency = await _repository.GetAsync(x => x.ID == id);
        if (currency is null)
        {
            return ServiceResponse.Failure(Constants.NotFound);
        }
        await _repository.DeleteAsync(currency);
        return ServiceResponse.Success(Constants.DeleteSuccessful);

    }
}
