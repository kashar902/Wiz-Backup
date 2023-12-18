namespace App.Wiz.Domain.ServiceDtos.FormulaBuilderDtos;

public class UpdateFormulaBuilderDto
{
    public UpdateFormulaBuilderDto()
    {
        ChargeFieldIds = new();
    }
    public int FormulaId { get; set; }
    public string? FormulaCode { get; set; }
    public string? FormulaTitle { get; set; }
    public string? FormulaDescription { get; set; }
    public string? Formula { get; set; }

    public List<ChargeFieldDtoId> ChargeFieldIds { get; set; }
}