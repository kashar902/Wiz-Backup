using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class CatalystDefault : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string DefaultCountry { get; set; }
		public string DefaultPaxType { get; set; }
		public string DefaultNationality { get; set; }
		public string DefaultVisitType { get; set; }
		public string DefaultInvoiceVisitType { get; set; }
		public string DefaultPaymentMode { get; set; }
		public string DefaultSaleStatus { get; set; }
		public string DefaultDoc { get; set; }
		public string DefaultTicketType { get; set; }
		public string DefaultGDS { get; set; }
		public string DefaultNoOfSector { get; set; }
		public string DefaultSupplierTicket { get; set; }
		public string DefaultSupplierHotel { get; set; }
		public string DefaultSupplierVisa { get; set; }
		public string DefaultSupplierTransaction { get; set; }
		public string DefaultSupplierGeneralBook { get; set; }
		public string DefaultSupplierInsurance { get; set; }
		public string DefaultInvoiceFormat { get; set; }
		//public string VoucherFormat { get; set; }
		//public string VoucherAllocationFormat { get; set; }
		//public string TicketTemplate { get; set; }
		//public string HotelTemplate { get; set; }
		//public string TransportTemplate { get; set; }
		//public string VisaTemplate { get; set; }
		//public string GeneralTemplate { get; set; }
		//public string InsuranceTemplate { get; set; }
		public string DefaultSPOCustomer { get; set; }
		public string DefaultCustomerType { get; set; }
		public string defaultBookingCategoryTicket { get; set; }
		public string DefaultCostingOption { get; set; }
		public string DefaultRefundStatus { get; set; }
		public string DefaultBookingCategoryHotel { get; set; }
		public string DefaultBookingCategoryTransport { get; set; }
		public string DefaultBookingCategoryVisa { get; set; }
		public string DefaultBookingCategoryOService { get; set; }
		public string DefaultExoNo { get; set; }
		public string DefaultGeneralVendor { get; set; }
		public string DefaultShift { get; set; }
		public string DefaultStaff { get; set; }
		public string DefaultHotel { get; set; }
		public string DefaultRoom { get; set; }
		public string DefaultRoomView { get; set; }
		public string DefaultTransporter { get; set; }
		public string DefaultVehicle { get; set; }
		public string DefaultVisaAgency { get; set; }
		public string DefaultVisaType { get; set; }
		public string DefaultInsuranceType { get; set; }
		//public string DefaulInsuranceVendor { get; set; }
		public int User_ID { get; set; }


	}
}
