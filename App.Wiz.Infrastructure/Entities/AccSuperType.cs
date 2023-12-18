using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

[Table("AccSuperType")]
public class AccSuperType
{
    [Key]
    public int ID { get; set; }
    public string? Name { get; set; }
}
