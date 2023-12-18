namespace App.Wiz.Common.ServiceViewModels.CurrencyViewModels;

public class CurrencyViewModel
{
    public int ID { get; set; }
    public string? CurrencyCode { get; set; }
    public string? CurrencyName { get; set; }
    public string? CurrencySymbol { get; set; }
    public string? Description { get; set; }
    public string? DecimalSeparator { get; set; }
    public string? Precision { get; set; }
    public string? ThousandSeparator { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public bool ActivateCurrency { get; set; }
}
