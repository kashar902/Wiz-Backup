using App.Wiz.Common.ServiceViewModels.DropdownViews;

namespace App.Wiz.Common.ServiceViewModels.AccountSetupViewModels;

public class GetAccountSetupFormModel
{
    public GetAccountSetupFormModel()
    {
        Customers = new List<GuidDropdown>();
        Suppliers = new List<GuidDropdown>();
        VoidCharges = new List<GuidDropdown>();
        BalanceEquities = new List<GuidDropdown>();
        ExchangeDiffs = new List<GuidDropdown>();
    }
    public List<GuidDropdown> Customers { get; set; }
    public List<GuidDropdown> Suppliers { get; set; }
    public List<GuidDropdown> VoidCharges { get; set; }
    public List<GuidDropdown> BalanceEquities { get; set; }
    public List<GuidDropdown> ExchangeDiffs { get; set; }
}
