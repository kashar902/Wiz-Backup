namespace UserAssociates.Business.Viewmodels;

public sealed class ChargeFieldViewModel
{
    public int ID { get; set; }
    public string? FieldCode { get; set; }
    public string? ChargeFieldName { get; set; }
    public string? FieldType { get; set; }
    public string? ChargeType { get; set; }
    public string? Position { get; set; }
    public string? Percentage { get; set; }
    public bool RoundOff { get; set; }
    public bool IsReadOnly { get; set; }
    public string? Description { get; set; }
}
