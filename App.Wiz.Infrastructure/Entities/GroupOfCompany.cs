using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class GroupOfCompany : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GOCID { get; set; }
    public string? GroupName { get; set; }
    public string? GroupDescription { get; set; }
    public string? StartDate { get; set; }
    public bool Active { get; set; }
    public int CurrencyId { get; set; }
    public Currency? Currency { get; set; }
}
