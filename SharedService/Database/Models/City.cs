using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedService.Database.Models;

public class City : BaseEntities
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }
	public string? CityName { get; set; }
	public string? CityCode { get; set; }
	public int CountryId { get; set; }
}
