using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;
public class Branch : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public bool IsActive { get; set; }
    public string? officeAddress { get; set; }
    public string? Postalcode { get; set; }
    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    public int CurrencyId { get; set; }
    public Currency? Currency { get; set; }
}
