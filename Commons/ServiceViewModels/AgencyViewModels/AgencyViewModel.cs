namespace App.Wiz.Common.ServiceViewModels.AgencyViewModels
{
    public class AgencyViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public string? officeAddress { get; set; }
        public string? Postalcode { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int CurrencyId { get; set; }
        public string? CurrencyName { get; set; }
    }
}
