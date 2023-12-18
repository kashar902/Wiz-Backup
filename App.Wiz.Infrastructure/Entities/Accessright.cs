using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities
{
    [Table("Accessrights")]
    public class Accessright
    {
        [Key]
        public int ID { get; set; }

        public bool CreatePermission { get; set; }

        public bool ReadPermission { get; set; }

        public bool UpdatePermission { get; set; }

        public bool DeletePermission { get; set; }
    }
}
