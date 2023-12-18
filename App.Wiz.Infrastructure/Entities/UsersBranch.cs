using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class UsersBranch : BaseEntities
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public int UserId { get; set; }
    public Users? User { get; set; }
    public int GroupOfCompanyId { get; set; }
    public GroupOfCompany? GroupOfCompany { get; set; }
    public int CompanyId { get; set; }
    public Company? Companies { get; set; }
    public int BranchId { get; set; }
    public Branch? Branch { get; set; }
    public bool DefaultBranch { get; set; }
}
