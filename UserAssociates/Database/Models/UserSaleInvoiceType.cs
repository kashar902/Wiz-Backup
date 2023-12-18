namespace UserAssociates.Database.Models
{
	public class UserSaleInvoiceType
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string BranchId { get; set; }
		public List<SaleInvoiceTypes> saleInvoiceTypes { get; set; }
	}

	public class SaleInvoiceTypes 
	{
		public string Id { get; set; }
		public string SaleInvoiceType { get; set; }
	}
}
