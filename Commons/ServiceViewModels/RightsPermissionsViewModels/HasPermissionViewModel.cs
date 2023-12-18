namespace App.Wiz.Common.ServiceViewModels.RightsPermissionsViewModels;

public class HasPermissionViewModel
{
    public int ResourceId { get; set; }
    public bool? CreatePermission { get; set; }
    public bool? ReadPermission { get; set; }
    public bool? UpdatePermission { get; set; }
    public bool? DeletePermission { get; set; }
}
