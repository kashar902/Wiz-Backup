using App.Wiz.Common.Helper;
using App.Wiz.Common.ServiceViewModels.AccountSetupViewModels;
using App.Wiz.Domain.Repositories.ControlAccountRepository;
using App.Wiz.Domain.Repositories.SubsidaryAccountRepository;
using App.Wiz.Domain.ServiceDtos.AccountSetupDto;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Application.Profiles.AccountSetupProfile;

public class AccountSetupProfile
{
    public static async Task<AccountSetupViewModel> PrepareToViewModel(AccountSetup entity,
        IControlAccountRepository controlAccountRepository,
        ISubsidaryAccountRepository subsidaryAccountRepository)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        AccountSetupViewModel accountSetupViewModel = new()
        {
            AccountSetupId = entity.Id,
            CustomerId = entity.CustomerId,
            CustomerName = await GetAccountTitle(entity.CustomerId, controlAccountRepository),
            SupplierId = entity.SupplierId,
            SupplierName = await GetAccountTitle(entity.SupplierId, controlAccountRepository),
            VoidChargeId = entity.VoidCharge,
            VoidChargeName = await GetAccountTitle(entity.VoidCharge, subsidaryAccountRepository),
            BalanceEquityId = entity.BalanceEquity,
            BalanceEquityName = await GetAccountTitle(entity.BalanceEquity, subsidaryAccountRepository),
            ExchangeDiffId = entity.ExchangeDiff,
            ExchangeDiffName = await GetAccountTitle(entity.ExchangeDiff, subsidaryAccountRepository)
        };
#pragma warning restore CS8604 // Possible null reference argument.
        return accountSetupViewModel;
    }
    private static async Task<string?> GetAccountTitle(string accountId, IControlAccountRepository repository)
    {
        AccControlAccount? account = await repository.GetAsync(x => x.ID == Guid.Parse(accountId));
        return account?.Title;
    }
    private static async Task<string?> GetAccountTitle(string accountId, ISubsidaryAccountRepository repository)
    {
        AccSubsidaryAccount? account = await repository.GetAsync(x => x.ID == Guid.Parse(accountId));
        return account?.Title;
    }

    public static AccountSetup PrepareToEntity(CreateAccountDto dto)
    {
        return new()
        {
            BalanceEquity = dto.BalanceEquity,
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            CustomerId = dto.CustomerId,
            ExchangeDiff = dto.ExchangeDiff,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            SupplierId = dto.SupplierId,
            VoidCharge = dto.VoidCharge,
        };
    }
    public static AccountSetup PrepareToEntity(UpdateAccountDto dto, AccountSetup entity)
    {
        entity.BalanceEquity = dto.BalanceEquity;
        entity.CreatedBy = Global.Username;
        entity.CreatedDate = DateTime.UtcNow;
        entity.CustomerId = dto.CustomerId;
        entity.ExchangeDiff = dto.ExchangeDiff;
        entity.ModifiedBy = Global.Username;
        entity.ModifiedDate = DateTime.UtcNow;
        entity.SupplierId = dto.SupplierId;
        entity.VoidCharge = dto.VoidCharge;
        return entity;
    }
}
