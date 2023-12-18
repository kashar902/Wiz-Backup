using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class VisaType : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
	}
}
