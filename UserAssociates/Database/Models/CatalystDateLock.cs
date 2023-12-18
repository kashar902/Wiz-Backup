using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class CatalystDateLock : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime DateLockStart { get; set; }
		public DateTime DateLockEnd { get; set; }
		public bool ApplyLockOnInvoices { get; set; }
		public bool ApplyLockOnRefundInvoices { get; set; }
		public bool ApplyLockOnVouchers { get; set; }
		public DateTime AdjustmentDateLockStart { get; set; }
		public DateTime AdjustmentDateLockEnd { get; set; }
		public bool ApplyLockOnAdjustmentInvoices { get; set; }
		public bool ApplyLockOnAdjustmentRefundInvoices { get; set; }
		public bool ApplyLockOnAdjustmentVouchers { get; set; }
		public DateTime AdjustmentDateForPVStart { get; set; }
		public DateTime AdjustmentDateForPVEnd { get; set; }
		public bool ApplyDateOnPVvoucher { get; set; }
		public DateTime AdjustmentDateForRVStart { get; set; }
		public DateTime AdjustmentDateForRVEnd { get; set; }
		public bool ApplyDateForRVVoucher { get; set; }
		public DateTime AdjustmentDateForJVStart { get; set; }
		public DateTime AdjustmentDateForJVEnd { get; set; }
		public bool ApplyAdjustmentDateForJVVoucher { get; set; }
		public DateTime AdjustmentDateForCashDepositStart { get; set; }
		public DateTime AdjustmentDateForCashDepositEnd { get; set; }
		public bool ApplyDateOnCashDepositVoucher { get; set; }
		public DateTime AdjustmentDateForDebitNoteStart { get; set; }
		public DateTime AdjustmentDateForDebitNoteEnd { get; set; }
		public bool ApplyDateOnDebitNoteVoucher { get; set; }
		public int User_ID { get; set; }
	}
}
