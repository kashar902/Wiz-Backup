namespace App.Wiz.Common.ServiceViewModels.ChargeFieldViewModels;

public class ChargeFieldViewModel
{
    public int ChargeFieldId { get; set; }

    public string? Code { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Position { get; set; }
    public int? FieldTypeId { get; set; }
    public string? FieldType { get; set; }
    public int? ChargeTypeId { get; set; }
    public string? ChargeType { get; set; }
    public bool? IsReadOnly { get; set; }
    public bool? IsPercent { get; set; }
    public bool? IsRoundOff { get; set; }
}
