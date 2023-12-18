using App.Wiz.Common.ServiceViewModels.DropdownViews;

namespace App.Wiz.Common.ServiceViewModels.FormulaBuilderResponse
{
    public class ChargeFieldDropDown
    {
        public ChargeFieldDropDown()
        {
            ChargeField = new List<Dropdown>();
        }
        public List<Dropdown> ChargeField { get; set; }
    }
}
