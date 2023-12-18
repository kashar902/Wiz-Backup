namespace App.Wiz.Common.ServiceViewModels.FormulaBuilderResponse;

public class FormulaBuilderResponse
{
    public FormulaBuilderResponse()
    {
        ChargeFieldIds = new List<FormulaBuilderChargeFieldDtoId>();
    }
    public int FormulaId { get; set; }
    public string? FormulaCode { get; set; }
    public string? FormulaTitle { get; set; }
    public string? FormulaDescription { get; set; }
    public string? Formula { get; set; }
    public List<FormulaBuilderChargeFieldDtoId> ChargeFieldIds { get; set; }
}
public class FormulaBuilderChargeFieldDtoId
{
    public int Id { get; set; }
}
