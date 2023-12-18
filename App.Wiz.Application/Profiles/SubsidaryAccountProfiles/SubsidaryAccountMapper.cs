using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.SubsidaryViewModels;
using App.Wiz.Domain.ServiceDtos.SubsidiaryAccountDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Profiles.SubsidaryAccountProfiles;

public static class SubsidaryAccountMapper
{
    public static SubsidaryAccountViewModel ToSubsidaryAccountViewModel(AccSubsidaryAccount request)
    {
        request.AccountCode = request.AccountCode.Remove(0, 1);
        return new()
        {
            ControlAccountId = request.ControlAccountId.ToString(),
            CurrencyId = request.CurrencyId,
            EndDate = request.EndDate,
            IsActive = request.IsActive,
            OpeningBalance = request.OpeningBalance,
            StartDate = request.StartDate,
            SuperTypeId = request.SuperTypeId,
            Title = request.Title,
            ID = request.ID.ToString(),
            AccountCode = request.AccountCode,
            ControlAccountName = request.ControlAccount?.Title ?? string.Empty,
            CurrencyName = request.Currency?.CurrencyName ?? string.Empty,
            SuperTypeName = request.SuperType?.Name ?? string.Empty,
            ExchangeRate = request.ExchangeRate,
            OpeningBalanceDate = request.OpeningBalanceDate,
        };
    }

    public static AccSubsidaryAccount ToAccSubsidaryAccount(CreateSubsidiaryAccountDto request)
    {
        return new()
        {
            ID = Guid.NewGuid(),
            CreatedBy = Global.Username,
            ModifiedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
            IsActive = request.IsActive,
            SuperTypeId = request.SuperTypeId,
            Title = request.Title,
            ControlAccountId = Guid.Parse(request.ControlAccountId),
            StartDate = !string.IsNullOrWhiteSpace(request.StartDate) ? DateTime.Parse(request.StartDate) : null,
            OpeningBalance = request.OpeningBalance ?? 0.0m,
            EndDate = !string.IsNullOrWhiteSpace(request.EndDate) ? DateTime.Parse(request.EndDate) : null,
            CurrencyId = request.CurrencyId,
            AccountCode = "1" + request.AccountCode,
            ExchangeRate = request.ExchangeRate,
            OpeningBalanceDate = !string.IsNullOrWhiteSpace(request.OpeningBalanceDate) ? DateTime.Parse(request.OpeningBalanceDate) : null,
        };
    }
    public static AccSubsidaryAccount ToAccSubsidaryAccount(UpdateSubsidiaryAccountDto request, AccSubsidaryAccount accSubsidaryAccount)
    {
        accSubsidaryAccount.ModifiedBy = Global.Username;
        accSubsidaryAccount.ModifiedDate = DateTime.UtcNow;
        accSubsidaryAccount.IsActive = request.IsActive;
        accSubsidaryAccount.SuperTypeId = request.SuperTypeId;
        accSubsidaryAccount.Title = request.Title;
        accSubsidaryAccount.ControlAccountId = request.ControlAccountId;
        accSubsidaryAccount.StartDate = !string.IsNullOrWhiteSpace(request.StartDate) ? DateTime.Parse(request.StartDate) : null;
        accSubsidaryAccount.OpeningBalance = request.OpeningBalance ?? 0.0m;
        accSubsidaryAccount.EndDate = !string.IsNullOrWhiteSpace(request.EndDate) ? DateTime.Parse(request.EndDate) : null;
        accSubsidaryAccount.CurrencyId = request.CurrencyId;
        accSubsidaryAccount.AccountCode = "1" + request.AccountCode;
        accSubsidaryAccount.ExchangeRate = request.ExchangeRate;
        accSubsidaryAccount.OpeningBalanceDate = !string.IsNullOrWhiteSpace(request.OpeningBalanceDate) ? DateTime.Parse(request.OpeningBalanceDate) : null;
        return accSubsidaryAccount;
    }
}
