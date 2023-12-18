namespace UserAssociates.Database.Models
{
	public class UserVoucherType
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string BranchId { get; set; }
		public List<VoucherTypes> voucherTypes { get; set; }
	}

	public class VoucherTypes 
	{
		public string Id { get; set; }
		public string VoucherType { get; set; }
	}
}
