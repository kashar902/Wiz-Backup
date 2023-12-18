using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class General : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public bool OpenmultipleInstancesOfSameReport { get; set; }
		public bool AlwaysRunJobsInBackground { get; set; }
		public int User_ID { get; set; }
	}
}
