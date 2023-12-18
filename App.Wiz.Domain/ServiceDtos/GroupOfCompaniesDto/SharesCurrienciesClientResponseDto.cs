namespace App.Wiz.Domain.ServiceDtos.GroupOfCompaniesDto;

public class SharesCurrienciesClientResponseDto
{
    public int? id { get; set; }
    public string? currencyCode { get; set; }
    public string? currencyName { get; set; }
    public string? currencySymbol { get; set; }
    public string? description { get; set; }
    public string? decimalSeparator { get; set; }
    public string? precision { get; set; }
    public string? thousandSeparator { get; set; }
    public DateTime effectiveDate { get; set; }
    public bool activateCurrency { get; set; }
}
