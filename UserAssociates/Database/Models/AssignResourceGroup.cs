using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class AssignResourceGroup : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int ResourceID { get; set; }
		public int GroupID { get; set; }
		public int GroupPriorityToUser { get; set; }
	}
}
