using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("AccControlAccount")]
public class AccControlAccount : BaseEntities
{
    [Key]
    public Guid ID { get; set; }
    public string? Title { get; set; }
    public string? ParentAccountId { get; set; }
    public string? AccountCode { get; set; }
    public int SuperTypeId { get; set; }
    public bool IsActive { get; set; }

    [ForeignKey("SuperTypeId")]
    public AccSuperType? SuperType { get; set; }

}
