using App.Wiz.Infrastructure.Entities;

namespace App.Wiz.Domain.ServiceDtos.TemplateDtos;

public class UpdateTemplateFieldDto
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

    public List<TemplateField> PrepareToTemplateField(List<TemplateField> entities)
    {
        foreach (var entity in entities)
        {
            entity.TemplateId = entity.TemplateId;
            entity.ChargeFieldId = ChargeFieldId;
            entity.FormulaBuilderId = FormulaBuilderId;
            entity.IsRefundCharges = IsRefundCharges;
            entity.IsCustomerEnabled = IsCustomer;
            entity.IsSupplierEnabled = IsSupplier;
            entity.CustomerCredit = CustomerCredit;
            entity.CustomerDebit = CustomerDebit;
            entity.CustomerValue = CustomerValue;
            entity.SupplierCredit = SupplierCredit;
            entity.SupplierDebit = SupplierDebit;
            entity.SupplierValue = SupplierValue;
            entity.FlightClassId = FlightClassId;
        }
        return entities;
    }
}
