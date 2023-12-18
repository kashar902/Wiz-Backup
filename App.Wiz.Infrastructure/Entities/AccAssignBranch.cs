using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class AccAssignBranch
{
    [Key]
    public int ID { get; set; }
    public string? ParentId { get; set; }
    public int BranchId { get; set; }
    public int CompanyId { get; set; }
    public bool IsControlAccount { get; set; }
    [ForeignKey("BranchId")]
    public Branch? Branch { get; set; }
    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
}
