using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class AssignMemberGroup : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int AssignedUserId { get; set; }
		public int GroupId { get; set; }
		public int GroupPriorityToUser { get; set; }
	}
}
