using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class CatalystGeneral : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public bool Currency { get; set; }
		public string AbacusMIRPath { get; set; }
		public string HotelVoucherFooter { get; set; }
		public string ReportFooter { get; set; }
		public string VoucherFooter { get; set; }
		public int user_id { get; set; }
	}
}
