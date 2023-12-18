using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("Groups")]
public class Group : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? GroupName { get; set; }
    public int GroupPriority { get; set; }
    public string? Description { get; set; }

    public ICollection<GroupDetails> GroupDetails { get; set; }
}
