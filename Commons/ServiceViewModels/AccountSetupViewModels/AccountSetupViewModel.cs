namespace App.Wiz.Common.ServiceViewModels.AccountSetupViewModels;

public class AccountSetupViewModel
{
    public int AccountSetupId { get; set; }
    public string? CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? VoidChargeId { get; set; }
    public string? VoidChargeName { get; set; }
    public string? BalanceEquityId { get; set; }
    public string? BalanceEquityName { get; set; }
    public string? ExchangeDiffId { get; set; }
    public string? ExchangeDiffName { get; set; }
}
