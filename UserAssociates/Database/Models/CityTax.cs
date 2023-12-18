using Commons.BaseEntity;

namespace UserAssociates.Database.Models
{
	public class CityTax : BaseEntities
	{
		public int ID { get; set; }
		public string Code { get; set; }
		public string Title { get; set; }
		public int Amount { get; set; }
		public string DebitAccount { get; set; }
		public string CreditAccount { get; set; }
	}
}
