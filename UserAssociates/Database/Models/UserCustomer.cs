namespace UserAssociates.Database.Models
{
	public class UserCustomer
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string BranchId {  get; set; }
		public List<Customer> customers { get; set; }
	}

	public class Customer 
	{
		public int Id { get; set; }
		public string CustomerName{ get; set; }
	}
}
