namespace App.Wiz.Common.ServiceViewModels.GroupViewModels;

public class GroupOfCompanyViewModel
{
    public int GroupOfCompanyId { get; set; }
    public string? GroupOfCompanyName { get; set; }
    public string? GroupDescription { get; set; }
    public string? StartDate { get; set; }
    public int CurrencyId { get; set; }
    public string? CurrencyName { get; set; }
    public bool Active { get; set; }
}