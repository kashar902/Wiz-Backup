namespace UserAssociates.Business.Viewmodels;

public sealed class FormulaBuilderViewModel
{
    public int KeyID { get; set; }
    public string? FormulaCode { get; set; }
    public string? FormulaName { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public string? Formula { get; set; }
    public bool Active { get; set; }
}
