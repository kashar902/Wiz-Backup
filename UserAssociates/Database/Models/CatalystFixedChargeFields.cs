using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class CatalystFixedChargeFields : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int FixedChargeFieldId { get; set; }
		public int FixedAvailableChargeFieldId { get; set; }
		public int OTHERChargeFieldId { get; set; }
		public int User_ID { get; set; }

	}
}
