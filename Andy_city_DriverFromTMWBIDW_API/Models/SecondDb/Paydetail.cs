using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models.SecondDb;

public partial class Paydetail
{
    public byte[]? Timestamp { get; set; }

    public int PydNumber { get; set; }

    public int? PyhNumber { get; set; }

    public int? LghNumber { get; set; }

    public int? AsgnNumber { get; set; }

    public string? AsgnType { get; set; }

    public string? AsgnId { get; set; }

    public int? IvdNumber { get; set; }

    public string? PydProrap { get; set; }

    public string? PydPayto { get; set; }

    public string? PytItemcode { get; set; }

    public int? MovNumber { get; set; }

    public string? PydDescription { get; set; }

    public string? PyrRatecode { get; set; }

    public double? PydQuantity { get; set; }

    public string? PydRateunit { get; set; }

    public string? PydUnit { get; set; }

    public decimal? PydRate { get; set; }

    public decimal? PydAmount { get; set; }

    public string? PydPretax { get; set; }

    public string? PydGlnum { get; set; }

    public string? PydCurrency { get; set; }

    public DateTime? PydCurrencydate { get; set; }

    public string? PydStatus { get; set; }

    public string? PydRefnumtype { get; set; }

    public string? PydRefnum { get; set; }

    public DateTime? PyhPayperiod { get; set; }

    public DateTime? PydWorkperiod { get; set; }

    public string? LghStartpoint { get; set; }

    public int? LghStartcity { get; set; }

    public string? LghEndpoint { get; set; }

    public int? LghEndcity { get; set; }

    public decimal? IvdPayrevenue { get; set; }

    public double? PydRevenueratio { get; set; }

    public decimal? PydLessrevenue { get; set; }

    public decimal? PydPayrevenue { get; set; }

    public DateTime? PydTransdate { get; set; }

    public int? PydMinus { get; set; }

    public int? PydSequence { get; set; }

    public int? StdNumber { get; set; }

    public string? PydLoadstate { get; set; }

    public int? PydXrefnumber { get; set; }

    public int? OrdHdrnumber { get; set; }

    public decimal? PytFee1 { get; set; }

    public decimal? PytFee2 { get; set; }

    public decimal? PydGrossamount { get; set; }

    public string? PydAdjFlag { get; set; }

    public string? PydUpdatedby { get; set; }

    public int? PsdId { get; set; }

    public DateTime? PydTransferdate { get; set; }

    public string? PydExportstatus { get; set; }

    public string? PydReleasedby { get; set; }

    public string? ChtItemcode { get; set; }

    public int? PydBilledweight { get; set; }

    public string? TarTarriffnumber { get; set; }

    public string? PsdBatchId { get; set; }

    public string? PydUpdsrc { get; set; }

    public DateTime? PydUpdatedon { get; set; }

    public int? PydOffsetpayNumber { get; set; }

    public string? PydCreditPayFlag { get; set; }

    public int? PydIvhHdrnumber { get; set; }

    public int? PsdNumber { get; set; }

    public string? PydRefInvoice { get; set; }

    public DateTime? PydRefInvoicedate { get; set; }

    public string? PydIgnoreglreset { get; set; }

    public string? PydAuthcode { get; set; }

    public short? PydPostProcSource { get; set; }

    public string? PydGptrans { get; set; }

    public string? CacId { get; set; }

    public string? CccId { get; set; }

    public DateTime? PydHourlypaydate { get; set; }

    public string? PydIsdefault { get; set; }

    public string? PydMaxquantityUsed { get; set; }

    public string? PydMaxchargeUsed { get; set; }

    public decimal? PydMbtaxableamount { get; set; }

    public decimal? PydNttaxableamount { get; set; }

    public string? PydCarinvnum { get; set; }

    public DateTime? PydCarinvdate { get; set; }

    public int? StdNumberAdj { get; set; }

    public string PydVendortopay { get; set; } = null!;

    public string? PydVendorpay { get; set; }

    public string? PydRemarks { get; set; }

    public string? PydPerdiemExceeded { get; set; }

    public DateTime? PydPaymentDate { get; set; }

    public string? PydPaymentDocNumber { get; set; }

    public int? StpNumber { get; set; }

    public int? StpMfhSequence { get; set; }

    public string? PydCarrierinvoiceAprv { get; set; }

    public string? PydCarrierinvoiceRjct { get; set; }

    public string? PydAprvRjctComment { get; set; }

    public string? PydPaidIndicator { get; set; }

    public decimal? PydPaidAmount { get; set; }

    public string? PydExpresscode { get; set; }

    public string? PydCreatedby { get; set; }

    public DateTime? PydCreatedon { get; set; }

    public int? StpNumberPacos { get; set; }

    public decimal? PydGstAmount { get; set; }

    public int? PydGstFlag { get; set; }

    public string? PydMileagetable { get; set; }

    public string? PytOtflag { get; set; }

    public string? BillOverride { get; set; }

    public string? NotBilledReason { get; set; }

    public DateTime? PydApCheckDate { get; set; }

    public string? PydApCheckNumber { get; set; }

    public decimal? PydApCheckAmount { get; set; }

    public string? PydApVendorId { get; set; }

    public string? PydApUpdatedBy { get; set; }

    public double? PydRegTimeQty { get; set; }

    public int? PydAdvstdnum { get; set; }

    public DateTime? PydMinPeriod { get; set; }

    public string? CrdCardnumber { get; set; }

    public int? PydIcoIvdNumberChild { get; set; }

    public string? PydApVoucherNbr { get; set; }

    public string? PydWorkcycleStatus { get; set; }

    public string? PydWorkcycleDescription { get; set; }

    public DateTime? StdPurchaseDate { get; set; }

    public string? StdPurchaseTaxState { get; set; }

    public int? PydTaxOriginatorPydNumber { get; set; }

    public double PydThirdpartySplitPercent { get; set; }

    public double? PydCoownerSplitPercent { get; set; }

    public string? PydCoownerSplitAdj { get; set; }

    public decimal? PydReportQuantity { get; set; }

    public decimal? PydReportRate { get; set; }

    public DateTime? PydClockStart { get; set; }

    public DateTime? PydClockEnd { get; set; }

    public string? PydLghtype1 { get; set; }

    public string? PydBranch { get; set; }

    public int? PydTprsplitNumber { get; set; }

    public int? PydTprdiffbtwNumber { get; set; }

    public int? PydAtdId { get; set; }

    public string? PydRemitToVendorId { get; set; }

    public int? PydSmwldId { get; set; }

    public string? PydOrigCurrency { get; set; }

    public decimal? PydOrigAmount { get; set; }

    public decimal? PydCexRate { get; set; }

    public int? PydPair { get; set; }

    public string? PydFixedRate { get; set; }

    public string? PydFixedAmount { get; set; }

    public string? TermCode { get; set; }

    public string? PydBasis { get; set; }

    public string? PydBasisunit { get; set; }

    public string? PydBranchOverride { get; set; }

    public string? PydBilltypeChangereason { get; set; }

    public string? PydDelays { get; set; }

    public int? PydRegTimePydnum { get; set; }

    public decimal? PydOverlimit { get; set; }

    public decimal? PydTotaladvanced { get; set; }

    public string? PydFixedQty { get; set; }

    public int? RecurringAdjustmentDetailId { get; set; }

    public int? PydParentPydNumber { get; set; }

    public double? PydRateFactor { get; set; }

    public byte[] DwTimestamp { get; set; } = null!;

    public bool? PydReconcile { get; set; }

    public int? PayScheduleId { get; set; }

    public bool? ExcludeGuaranteePay { get; set; }
}
