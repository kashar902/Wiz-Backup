using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class Groups : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Group_Name { get; set; }
		public int Creat_User_ID { get; set; }
		public string Description { get; set; }
		public DateTime Creation_Date { get; set; }
	}
}
