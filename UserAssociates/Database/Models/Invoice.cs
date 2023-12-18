using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class Invoice : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string InvoiceCode { get; set; }
		public int InvoiceDetailId { get; set; }
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public int CustomerId { get; set; }
		public int SupplierId { get; set; }
	}
}
