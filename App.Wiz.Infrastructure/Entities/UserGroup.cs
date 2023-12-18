using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("UserGroups")]
public class UserGroup : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public int? UserId { get; set; }
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
    public Users? User { get; set; }

}