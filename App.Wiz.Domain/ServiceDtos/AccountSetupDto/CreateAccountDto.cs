using App.Wiz.Common.Helper;
using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.ServiceDtos.AccountSetupDto;

public class CreateAccountDto
{
    public string? CustomerId { get; set; }
    public string? SupplierId { get; set; }
    public string? VoidCharge { get; set; }
    public string? BalanceEquity { get; set; }
    public string? ExchangeDiff { get; set; }


    public AccountSetup PrepareToEnttiy()
    {
        return new AccountSetup
        {
            BalanceEquity = BalanceEquity,
            CreatedBy = Global.Username,
            CreatedDate = DateTime.UtcNow,
            CustomerId = CustomerId,
            ExchangeDiff = ExchangeDiff,
            ModifiedBy = Global.Username,
            ModifiedDate = DateTime.UtcNow,
            SupplierId = SupplierId,
            VoidCharge = VoidCharge,
        };
    }
}
