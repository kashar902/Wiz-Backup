using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class License : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public int LicenseCat { get; set; }
    public DateTime startdate { get; set; }
    public DateTime enddate { get; set; }
    public int? BranchId { get; set; }
    public Branch? Branch { get; set; }
}
