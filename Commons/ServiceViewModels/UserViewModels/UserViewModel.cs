namespace App.Wiz.Common.ServiceViewModels.UserViewModels;

public class UserViewModel
{
    public int ID { get; set; }
    public string? UserName { get; set; }
    public string? DisplayName { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserRole { get; set; }
    public string? Agency { get; set; }
    public bool IsActive { get; set; }
}