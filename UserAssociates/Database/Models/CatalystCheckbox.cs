using Commons.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAssociates.Database.Models
{
	public class CatalystCheckbox : BaseEntities
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public bool IncCustInReports { get; set; }
		public bool ShowCurrOnInvPrint { get; set; }
		public bool NoSPOnInvPrint { get; set; }
		public bool NoPSFOnInvPrint { get; set; }
		public bool ShwRankInSearch { get; set; }
		public bool NoKBOnInvPrint { get; set; }
		public bool NoSSTOnInvPrint { get; set; }
		public bool ShwSSTInsteadOfGST { get; set; }
		public bool InclDOFTaxWithFare { get; set; }
		public bool InclYQTaxWithFare { get; set; }
		public bool InclRefundInvTotalInNetFormat { get; set; }
		public bool MsgInsteadOfSigInPWZTourInv { get; set; }
		public bool DisVoucherAlloc { get; set; }
		public bool ChkInvVoucherValidation { get; set; }
		public bool AddBranchCodeToVoucherNumReports { get; set; }
		public bool RstrctCustIfCredLimitExceeds { get; set; }
		public bool RstrctCustIfCredLimitExceedsWithOpenInv { get; set; }
		public bool ShwDlgWhileInvPrinting { get; set; }
		public bool AllowTktNumChangeOnRefundInv { get; set; }
		public bool Shw2ndLogoOnReports { get; set; }
		public bool NoHeaderFooterOnInvPrint { get; set; }
		public bool AllowEditSupplierAndVendorInRefund { get; set; }
		public bool InLegVoucherGetAdjDateAgainstRefCodeAndSetInAdjDateCol { get; set; }
		public bool ChkDupPNROnSameBranch { get; set; }
		public bool AllowDupTktEntryOnDiffBranch { get; set; }
		public bool EnblVisibleToAllBranchesInCustDialog { get; set; }
		public bool RstrctRefundAmt { get; set; }
		public bool MandAirlineNameOnCust { get; set; }
		public bool EnblVisibleToCheckboxScreenAllBranchesInSuppDialog { get; set; }
		public bool EnblVisibleToAllBranchesInChartOfAccts { get; set; }
		public bool AutoGenTktNumForSelAirlines { get; set; }
		public bool CurrExchRateToApplyVsSaleInvDateInBooking { get; set; }
		public bool FreezePayableCharges { get; set; }
		public bool ChkForGenSearch { get; set; }
		public bool ValTktFareWithAdminTktFare { get; set; }
		public bool ApplyCalcForDurQtyOnHotelBooking { get; set; }
		public bool PrntDupInvOnPrinting { get; set; }
		public bool DisInvVoucherNumInput { get; set; }
		public bool MandPassportNumAndPassportDate { get; set; }
		public bool InclCentralCustForBatchPolicy { get; set; }
		public bool DisPaymentVoucherFields { get; set; }
		public bool PostVoucherOnSave { get; set; }
		public bool HideVoidButtonInLegVoucher { get; set; }
		public bool MandPNROnInv { get; set; }
		public bool MandSPOOnInv { get; set; }
		public bool MandIATAOnInv { get; set; }
		public bool DisAdjDateOnPmtVoucher { get; set; }
		public bool ChkToInclPostedVoucherOnly { get; set; }
		public bool AutoSetAdjDateToCurrentDateOnPosting { get; set; }
		public bool AutoSetIssueDateAsInvDate { get; set; }
		public bool AllowHalfRefundInTktBooking { get; set; }
		public bool AlwaysChangeInvPrintNameWhenCustChanges { get; set; }
		public bool RstrctPmtVoucherWhichExceedsCurrDebitAmtOfCashBankAcctsInLegVoucher { get; set; }
		public bool RstrctInvType { get; set; }
		public bool DisInvDate { get; set; }
		public bool DisRefundDate { get; set; }
		public bool DisVoucherDate { get; set; }
		public bool DisAdjDateOnInv { get; set; }
		public bool FreezeVoucherDateOnSave { get; set; }
		public bool VerCustWRefToInvInLegReceiptVoucher { get; set; }
		public bool NoRevInvStatusToQuotation { get; set; }
		public bool UseLegVoucherNumSeqStrategyInAllocVoucher { get; set; }
		public bool DisAuditTrail { get; set; }
		public bool EnblTransBusInGenBooking { get; set; }
		public bool AutoSetVoucherDateToCurrDateOnPosting { get; set; }
		public bool AuditSaleInv { get; set; }
		public bool ChqBookEntry { get; set; }
		public bool ManReceiptNoAndMand { get; set; }
		public bool SBPCodeMand { get; set; }
		public bool ShwModBy { get; set; }
		public bool RestrictTTPosting { get; set; }
		public bool RestrictRefundPosting { get; set; }
		//public bool RestrictRefundPostingWithBelowAmountOfReceivableOfSupplier { get; set; }
		public bool DisablePayment { get; set; }
		public int User_ID { get; set; }

	}
}
