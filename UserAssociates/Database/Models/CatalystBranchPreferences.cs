using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class CatalystBranchPreferences : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string DefaultPostingBranch { get; set; }
		public string ReportingBranches { get; set; }
		public int User_ID { get; set; }
	}
}
