namespace App.Wiz.Common.ServiceViewModels.SuperTypeViewModels;

public class SuperTypeViewModel
{
    public SuperTypeViewModel()
    {
        SuperType = new List<SuperTypeModel>();
    }
    public List<SuperTypeModel> SuperType { get; set; }
    public string Masking { get; set; }
}
public class SuperTypeModel
{
    public int SuperTypeId { get; set; }
    public string? SuperTypeName { get; set; }
}
