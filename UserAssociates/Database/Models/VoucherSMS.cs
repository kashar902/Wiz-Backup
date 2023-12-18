using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class VoucherSMS : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string ConfigurationURL { get; set; }
		public string ConfigurationUserName { get; set; }
		public string ConfigurationPassword { get; set; }
		public string ConfigurationVoucherMessage { get; set; }
		public bool ConfigurationAllowSMSAlertService { get; set; }
		public int User_ID { get; set; }
	}
}
