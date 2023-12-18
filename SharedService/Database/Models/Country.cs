using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedService.Database.Models;

public class Country : BaseEntities
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }
	public string? CountryName { get; set; }
	public string? CountryCode { get; set; }
}
