using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.CityTaxDto
{
	public class CreateCityTaxDto : CreateDtoBaseEntities
	{
		[Required]
		public string Code { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public int Amount { get; set; }
		[Required]
		public string DebitAccount { get; set; }
		[Required]
		public string CreditAccount { get; set; }
	}
}
