using App.Wiz.Common.ServiceViewModels.DropdownViews;

namespace App.Wiz.Common.ServiceViewModels.ChargeFieldViewModels;

public class ChargeFieldFormModel
{
    public ChargeFieldFormModel()
    {
        FieldType = new List<Dropdown>();
        ChargeType = new List<Dropdown>();
    }
    public List<Dropdown> FieldType { get; set; }
    public List<Dropdown> ChargeType { get; set; }
}
