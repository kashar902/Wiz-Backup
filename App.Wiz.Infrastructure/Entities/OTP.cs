using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class OTP : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? PhoneNumber { get; set; }
    public string? OTPnumber { get; set; }
}
