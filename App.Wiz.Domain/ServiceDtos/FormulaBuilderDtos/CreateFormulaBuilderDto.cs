namespace App.Wiz.Domain.ServiceDtos.FormulaBuilderDtos;

public class CreateFormulaBuilderDto
{
    public CreateFormulaBuilderDto()
    {
        ChargeFieldIds = new();
    }
    public string? FormulaCode { get; set; }
    public string? FormulaTitle { get; set; }
    public string? FormulaDescription { get; set; }
    public string? Formula { get; set; }

    public List<ChargeFieldDtoId> ChargeFieldIds { get; set; }
}
