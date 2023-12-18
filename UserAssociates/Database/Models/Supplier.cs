using Commons.BaseEntity;

namespace UserAssociates.Database.Models
{
	public class Supplier : BaseEntities
	{
		public int Id { get; set; }
		public string SupplierCode { get; set; }
		public string SupplierTitle { get; set; }
		public string ShortName { get; set; }
		public string Details { get; set; }
		public string Currency { get; set; }

		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string Phone1 { get; set; }
		public string Phone2 { get; set; }
		public string Fax { get; set; }
		public string ContactPersonName { get; set; }
		public string ContactPersonDesignation { get; set; }
		public string ContactPersonCellPhone { get; set; }
		public string ContactPersonPhone { get; set; }
		public string ContactPersonFax { get; set; }
		public string ContactPersonEmail { get; set; }

		public string GLAccount { get; set; }
		public int CreditLimit { get; set; }

		public bool CreateAutoLedgerAccountCheckbox { get; set; }
		public bool AddAllVendorsCheckbox { get; set; }

		public string Field { get; set; }
		public string Formula { get; set; }
		public string Value { get; set; }
		public string CreditAccount { get; set; }
		public string DebitAccount { get; set; }

		public bool IsCustomerEnabled { get; set; }
		public bool IsSupplierEnabled { get; set; }


	}
}
