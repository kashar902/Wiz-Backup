using App.Wiz.Common.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Wiz.Infrastructure.Entities;

public class FlightClasses : BaseEntities
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? Title { get; set; }
    public int? FlightClassCategoryId { get; set; }
    public FlightClassCategory? FlightClassCategory { get; set; }
    public string? Description { get; set; }
}
