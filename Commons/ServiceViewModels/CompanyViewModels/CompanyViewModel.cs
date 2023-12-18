namespace App.Wiz.Common.ServiceViewModels.CompanyViewModels
{
    public class CompanyViewModel
    {
        public int ID { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? Masking { get; set; }
        public string? StartDate { get; set; }
        public bool Active { get; set; }
        public GroupOfCompanyModel? GroupOfCompany { get; set; }
        public CurrencyModel? Currency { get; set; }
    }
    public class GroupOfCompanyModel
    {
        public int GroupOfCompanyId { get; set; }
        public string? GroupOfCompanyName { get; set; }
    }
    public class CurrencyModel
    {
        public int CurrencyId { get; set; }
        public string? CurrencyName { get; set; }
    }
}
