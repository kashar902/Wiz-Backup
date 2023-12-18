using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedService.Database.Models;

public class FlightClasses : BaseEntities
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }
	public string? Title { get; set; }
	public int FlightClassCategoryId { get; set; }
	public string? Description { get; set; }
}
