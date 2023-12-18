using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities
{
    [Table("UserResource")]
    public class UsersResource : BaseEntities
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public Users? User { get; set; }
        public int ResourceId { get; set; }
        public Resource? Resource { get; set; }
        public int? RightsId { get; set; }
        public Accessright? Rights { get; set; }
    }
}
