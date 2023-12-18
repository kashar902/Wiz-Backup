using App.Wiz.Common.ServiceViewModels.TemplateViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static App.Wiz.Common.Messages.TagsConstants;

namespace App.Wiz.Infrastructure.Entities;

[Table("TemplateField")]
public class TemplateField
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [ForeignKey("Template")]
    public int TemplateId { get; set; }

    [ForeignKey("ChargeField")]
    public int ChargeFieldId { get; set; }

    [ForeignKey("FormulaBuilder")]
    public int? FormulaBuilderId { get; set; }

    public bool IsRefundCharges { get; set; }
    public bool IsCustomerEnabled { get; set; }
    public bool IsSupplierEnabled { get; set; }

    public string? CustomerCredit { get; set; }
    public string? CustomerDebit { get; set; }
    public int? CustomerValue { get; set; }
    public string? SupplierCredit { get; set; }
    public string? SupplierDebit { get; set; }
    public int? SupplierValue { get; set; }
    public int? FlightClassId { get; set; }
    public FlightClassCategory? FlightClass { get; set; }

    public virtual Template? Template { get; set; }
    public virtual ChargeField? ChargeField { get; set; }
    public virtual FormulaBuilder? FormulaBuilder { get; set; }

    public TemplateFieldsViewModel PrepareToTemplateFieldsViewModel()
    {
        return new()
        {
            ChargeFieldId = ChargeFieldId,
            ChargeFieldName = ChargeField?.Title,
            FormulaBuilderId = FormulaBuilderId,
            FormulaBuilderName = FormulaBuilder?.Title,
            IsRefundCharges = IsRefundCharges,
            IsCustomer = IsCustomerEnabled,
            IsSupplier = IsSupplierEnabled,
            CustomerCredit = CustomerCredit,
            CustomerDebit = CustomerDebit,
            CustomerValue = CustomerValue,
            SupplierCredit = SupplierCredit,
            SupplierDebit = SupplierDebit,
            SupplierValue = SupplierValue,
            FlightClass = Class,
            TemplateId = TemplateId,
            
        };
    }
}