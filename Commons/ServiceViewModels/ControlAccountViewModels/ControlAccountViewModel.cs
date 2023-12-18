using App.Wiz.Common.ServiceViewModels.CompanyViewModels;

namespace App.Wiz.Common.ServiceViewModels.ControlAccountViewModels;

public class ControlAccountViewModel
{
    public ControlAccountViewModel()
    {
        CompaniesData = new List<CompanyDataViewModel>();
    }
    public string ControlAccountId { get; set; }
    public string Title { get; set; }
    public string? ParentAccountId { get; set; }
    public string ParentAccount { get; set; }
    public string AccountCode { get; set; }
    public string NewAccountCode { get; set; }
    public int SuperTypeId { get; set; }
    public string SuperTypeName { get; set; }
    public bool IsActive { get; set; }
    public List<CompanyDataViewModel> CompaniesData { get; set; }
    public bool IsDeleteable { get; set; }
    public int CurrencyId { get; set; }
}