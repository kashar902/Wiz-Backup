using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.ServiceDtos.TemplateDtos;

public class CreateTemplateFieldDto
{
    public int ChargeFieldId { get; set; }
    public int? FormulaBuilderId { get; set; }

    public bool IsRefundCharges { get; set; }
    public bool IsCustomer { get; set; }
    public int? FlightClassId { get; set; }
    public bool IsSupplier { get; set; }
    public string? CustomerCredit { get; set; }
    public string? CustomerDebit { get; set; }
    public int? CustomerValue { get; set; }
    public string? SupplierCredit { get; set; }
    public string? SupplierDebit { get; set; }
    public int? SupplierValue { get; set; }

    public TemplateField PrepareToTemplateField(int templateId)
    {
        return new TemplateField()
        {
            TemplateId = templateId,
            ChargeFieldId = ChargeFieldId,
            FormulaBuilderId = FormulaBuilderId,
            IsRefundCharges = IsRefundCharges,
            IsCustomerEnabled = IsCustomer,
            IsSupplierEnabled = IsSupplier,
            CustomerCredit = CustomerCredit,
            CustomerDebit = CustomerDebit,
            CustomerValue = CustomerValue,
            SupplierCredit = SupplierCredit,
            SupplierDebit = SupplierDebit,
            SupplierValue = SupplierValue,
            FlightClassId = FlightClassId
        };
    }
}
