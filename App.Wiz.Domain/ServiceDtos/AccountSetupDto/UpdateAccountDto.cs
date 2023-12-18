using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.ServiceDtos.AccountSetupDto;

public class UpdateAccountDto
{
    public int Id { get; set; }
    public string? CustomerId { get; set; }
    public string? SupplierId { get; set; }
    public string? VoidCharge { get; set; }
    public string? BalanceEquity { get; set; }
    public string? ExchangeDiff { get; set; }

    public AccountSetup PrepareToEnttiy(AccountSetup entity)
    {
        entity.BalanceEquity = BalanceEquity;
        entity.CustomerId = CustomerId;
        entity.ExchangeDiff = ExchangeDiff;
        entity.ModifiedBy = Global.Username;
        entity.ModifiedDate = DateTime.UtcNow;
        entity.SupplierId = SupplierId;
        entity.VoidCharge = VoidCharge;
        return entity;
    }
}
