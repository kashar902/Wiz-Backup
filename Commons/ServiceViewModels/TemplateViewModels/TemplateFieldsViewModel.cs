namespace App.Wiz.Common.ServiceViewModels.TemplateViewModels;

public class TemplateFieldsViewModel
{
    public int ChargeFieldId { get; set; }
    public int TemplateId { get; set; }
    public string? ChargeFieldName { get; set; }
    public int? FormulaBuilderId { get; set; }
    public string? FormulaBuilderName { get; set; }

    public bool IsRefundCharges { get; set; }
    public bool IsCustomer { get; set; }
    public bool IsSupplier { get; set; }

    public string? CustomerCredit { get; set; }
    public string? CustomerDebit { get; set; }
    public int? CustomerValue { get; set; }
    public string? SupplierCredit { get; set; }
    public string? SupplierDebit { get; set; }
    public int? SupplierValue { get; set; }
    public string? FlightClass { get; set; }
    public string? SupplierDebitName { get; set; }
    public string? SupplierCreditName { get; set; }
    public string? CustomerDebitName { get; set; }
    public string? CustomerCreditName { get; set; }

}
