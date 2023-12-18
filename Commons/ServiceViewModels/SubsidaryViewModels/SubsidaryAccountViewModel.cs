using App.Wiz.Common.ServiceViewModels.AccBudgetViewModels;
using App.Wiz.Common.ServiceViewModels.CompanyViewModels;

namespace App.Wiz.Common.ServiceViewModels.SubsidaryViewModels;

public class SubsidaryAccountViewModel
{
    public SubsidaryAccountViewModel()
    {
        CompaniesData = new List<CompanyDataViewModel>();
    }
    public string ID { get; set; }
    public string Title { get; set; }
    public string ControlAccountId { get; set; }
    public string ControlAccountName { get; set; }
    public int CurrencyId { get; set; }
    public string CurrencyName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? OpeningBalance { get; set; }
    public DateTime? OpeningBalanceDate { get; set; }
    public decimal? ExchangeRate { get; set; }
    public int SuperTypeId { get; set; }
    public string SuperTypeName { get; set; }
    public bool IsActive { get; set; }
    public string AccountCode { get; set; }
    public List<CompanyDataViewModel> CompaniesData { get; set; }
    public List<AccBudgetViewModel> AccBudget { get; set; }
}