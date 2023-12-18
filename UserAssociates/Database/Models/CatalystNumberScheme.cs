using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class CatalystNumberScheme : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string InvoiceNumberScheme { get; set; }
		public string InvoicePrefix { get; set; }
		public string RefundInvoicePrefix { get; set; }
		public string VoucherNumberScheme { get; set; }
		public int User_ID { get; set; }

	}
}
