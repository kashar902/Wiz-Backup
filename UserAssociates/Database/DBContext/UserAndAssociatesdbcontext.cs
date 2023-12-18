using Microsoft.EntityFrameworkCore;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.DBContext
{
	public class UserAndAssociatesdbcontext : DbContext
	{
		public UserAndAssociatesdbcontext(DbContextOptions<UserAndAssociatesdbcontext> options)
			: base(options)
		{

		}

		public UserAndAssociatesdbcontext() { }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<CatalystGeneral> Userpref_CatGeneral { get; set; }
		public virtual DbSet<CatalystDefault> Userpref_CatDefault { get; set; }
		public virtual DbSet<CatalystCheckbox> Userpref_CatCheckbox { get; set; }
		public virtual DbSet<CatalystDateLock> Userpref_DateLock { get; set; }
		public virtual DbSet<CatalystNumberScheme> Userpref_InvoiceNumscheme { get; set; }
		public virtual DbSet<CatalystFixedChargeFields> Userpref_ChargeFields { get; set; }
		public virtual DbSet<CatalystBranchPreferences> Userpref_BranchPreferences { get; set; }
		public virtual DbSet<General> Userpref_General { get; set; }
		public virtual DbSet<HotelInventory> Userpref_HotelInventory { get; set; }
		public virtual DbSet<VisaSMS> Userpref_VisaSMS { get; set; }
		public virtual DbSet<VoucherSMS> Userpref_VoucherSMS { get; set; }
		public virtual DbSet<Groups> Groups { get; set; }
		public virtual DbSet<Resources> Resource { get; set; }
		public virtual DbSet<AssignResourceGroup> AssignResourcetoGroup { get; set; }
		public virtual DbSet<AssignMemberGroup> AssignMemberGroup { get; set; }
		public virtual DbSet<Invoice> Invoices { get; set; }
		public virtual DbSet<BookingCategory> BookingCategories { get; set; }
		public virtual DbSet<CustomerType> CustomerTypes { get; set; }
		public virtual DbSet<ChargeField> ChargeFields { get; set; }
		public virtual DbSet<FormulaBuilder> FormulaBuilders { get; set; }
		public virtual DbSet<VisaType> VisaTypes { get; set; }
		public virtual DbSet<VisitType> VisitTypes { get; set; }
		public virtual DbSet<VoucherType> VoucherTypes { get; set; }

		public virtual DbSet<CityTax> CityTaxes { get; set; }

		public virtual DbSet<Supplier> Suppliers { get; set; }
		public virtual DbSet<UserPreferences> UserPreferences { get; set; }

	}
}
