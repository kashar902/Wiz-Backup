using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("GroupDetail")]
public class GroupDetails
{
    public int ID { get; set; }
    public int GroupId { get; set; }
    public int ResourceId { get; set; }
    public int AccessRightId { get; set; }
    public Group? Group { get; set; }
    public Resource? Resource { get; set; }
    public Accessright? AccessRight { get; set; }
}
