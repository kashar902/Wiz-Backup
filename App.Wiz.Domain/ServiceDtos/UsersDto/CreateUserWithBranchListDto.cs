using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace App.Wiz.Domain.ServiceDtos.UsersDto
{
    public class CreateUserWithBranchListDto : CreateDtoBaseEntities
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? DisplayName { get; set; }
        [Required]
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
    }

    public class BranchCompanyPair
    {
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }
    }
    public class AssignBranchDto
    {
        public AssignBranchDto()
        {
            BranchCompanyPairs = new List<BranchCompanyPair>();
        }
        
        public List<BranchCompanyPair> BranchCompanyPairs { get; set; }
        public int UserId { get; set; }
    }
}
