namespace App.Wiz.Common.ServiceViewModels.UserViewModels
{
    public class UserProfileViewModel
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public int GroupOfCompanyId { get; set; }
        public string? GroupOfCompanyName { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
    }
}
