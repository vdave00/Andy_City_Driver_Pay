using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models.SecondDb;

public partial class Orderheader
{
    public string OrdCompany { get; set; } = null!;

    public string OrdNumber { get; set; } = null!;

    public string? OrdCustomer { get; set; }

    public DateTime? OrdBookdate { get; set; }

    public string? OrdBookedby { get; set; }

    public string? OrdStatus { get; set; }

    public string? OrdOriginpoint { get; set; }

    public string? OrdDestpoint { get; set; }

    public string? OrdInvoicestatus { get; set; }

    public int? OrdOrigincity { get; set; }

    public int? OrdDestcity { get; set; }

    public string? OrdOriginstate { get; set; }

    public string? OrdDeststate { get; set; }

    public string? OrdOriginregion1 { get; set; }

    public string? OrdDestregion1 { get; set; }

    public string? OrdSupplier { get; set; }

    public string? OrdBillto { get; set; }

    public DateTime? OrdStartdate { get; set; }

    public DateTime? OrdCompletiondate { get; set; }

    public string? OrdRevtype1 { get; set; }

    public string? OrdRevtype2 { get; set; }

    public string? OrdRevtype3 { get; set; }

    public string? OrdRevtype4 { get; set; }

    public double? OrdTotalweight { get; set; }

    public decimal? OrdTotalpieces { get; set; }

    public int? OrdTotalmiles { get; set; }

    public double? OrdTotalcharge { get; set; }

    public string? OrdCurrency { get; set; }

    public DateTime? OrdCurrencydate { get; set; }

    public double? OrdTotalvolume { get; set; }

    public int OrdHdrnumber { get; set; }

    public string? OrdRefnum { get; set; }

    public string? OrdInvoicewhole { get; set; }

    public string? OrdRemark { get; set; }

    public string? OrdShipper { get; set; }

    public string? OrdConsignee { get; set; }

    public string? OrdPuAt { get; set; }

    public string? OrdDrAt { get; set; }

    public string? OrdOriginregion2 { get; set; }

    public string? OrdOriginregion3 { get; set; }

    public string? OrdOriginregion4 { get; set; }

    public string? OrdDestregion2 { get; set; }

    public string? OrdDestregion3 { get; set; }

    public string? OrdDestregion4 { get; set; }

    public int? MfhHdrnumber { get; set; }

    public string? OrdPriority { get; set; }

    public int? MovNumber { get; set; }

    public string? TarTarriffnumber { get; set; }

    public int? TarNumber { get; set; }

    public byte[]? Timestamp { get; set; }

    public string? TarTariffitem { get; set; }

    public string? OrdContact { get; set; }

    public string? OrdShowshipper { get; set; }

    public string? OrdShowcons { get; set; }

    public string? OrdSubcompany { get; set; }

    public int? OrdLowtemp { get; set; }

    public int? OrdHitemp { get; set; }

    public double? OrdQuantity { get; set; }

    public decimal? OrdRate { get; set; }

    public decimal? OrdCharge { get; set; }

    public string? OrdRateunit { get; set; }

    public string? OrdUnit { get; set; }

    public string? TrlType1 { get; set; }

    public string? OrdDriver1 { get; set; }

    public string? OrdDriver2 { get; set; }

    public string? OrdTractor { get; set; }

    public string? OrdTrailer { get; set; }

    public decimal? OrdLength { get; set; }

    public decimal? OrdWidth { get; set; }

    public decimal? OrdHeight { get; set; }

    public string? OrdLengthunit { get; set; }

    public string? OrdWidthunit { get; set; }

    public string? OrdHeightunit { get; set; }

    public string? OrdReftype { get; set; }

    public string? CmdCode { get; set; }

    public string? OrdDescription { get; set; }

    public string? OrdTerms { get; set; }

    public string? ChtItemcode { get; set; }

    public DateTime? OrdOriginEarliestdate { get; set; }

    public DateTime? OrdOriginLatestdate { get; set; }

    public int? OrdOdmetermiles { get; set; }

    public byte? OrdStopcount { get; set; }

    public DateTime? OrdDestEarliestdate { get; set; }

    public DateTime? OrdDestLatestdate { get; set; }

    public string? RefSid { get; set; }

    public string? RefPickup { get; set; }

    public decimal? OrdCmdvalue { get; set; }

    public decimal? OrdAccessorialChrg { get; set; }

    public DateTime? OrdAvailabledate { get; set; }

    public decimal? OrdMiscqty { get; set; }

    public string? OrdTempunits { get; set; }

    public DateTime? OrdDatetaken { get; set; }

    public string? OrdTotalweightunits { get; set; }

    public string? OrdTotalvolumeunits { get; set; }

    public string? OrdTotalcountunits { get; set; }

    public double? OrdLoadtime { get; set; }

    public double? OrdUnloadtime { get; set; }

    public double? OrdDrivetime { get; set; }

    public string? OrdRateby { get; set; }

    public int? OrdQuantityType { get; set; }

    public string? OrdThirdpartytype1 { get; set; }

    public string? OrdThirdpartytype2 { get; set; }

    public short? OrdChargeType { get; set; }

    public string? OrdBolPrinted { get; set; }

    public string? OrdFromorder { get; set; }

    public short? OrdMintemp { get; set; }

    public short? OrdMaxtemp { get; set; }

    public string? OrdDistributor { get; set; }

    public string? OptTrcType4 { get; set; }

    public string? OptTrlType4 { get; set; }

    public decimal? OrdCodAmount { get; set; }

    public string? ApptInit { get; set; }

    public string? ApptContact { get; set; }

    public double? OrdRatingquantity { get; set; }

    public string? OrdRatingunit { get; set; }

    public string? OrdHideshipperaddr { get; set; }

    public string? OrdHideconsignaddr { get; set; }

    public string OrdBookedRevtype1 { get; set; } = null!;

    public string? OrdMileagetable { get; set; }

    public int? OrdTareweight { get; set; }

    public int? OrdGrossweight { get; set; }

    public string? OrdTrlType2 { get; set; }

    public string? OrdTrlType3 { get; set; }

    public string? OrdTrlType4 { get; set; }

    public decimal? OrdAllinclusivecharge { get; set; }

    public string? OrdExtrainfo1 { get; set; }

    public string? OrdExtrainfo2 { get; set; }

    public string? OrdExtrainfo3 { get; set; }

    public string? OrdExtrainfo4 { get; set; }

    public string? OrdExtrainfo5 { get; set; }

    public string? OrdExtrainfo6 { get; set; }

    public string? OrdExtrainfo7 { get; set; }

    public string? OrdExtrainfo8 { get; set; }

    public string? OrdExtrainfo9 { get; set; }

    public string? OrdExtrainfo10 { get; set; }

    public string? OrdExtrainfo11 { get; set; }

    public string? OrdExtrainfo12 { get; set; }

    public string? OrdExtrainfo13 { get; set; }

    public string? OrdExtrainfo14 { get; set; }

    public string? OrdExtrainfo15 { get; set; }

    public short? OrdRateType { get; set; }

    public string? OrdBarcode { get; set; }

    public string? OrdBroker { get; set; }

    public double? OrdStlquantity { get; set; }

    public string? OrdStlunit { get; set; }

    public byte? OrdStlquantityType { get; set; }

    public int? OrdFromschedule { get; set; }

    public int? OrdSchedulebatch { get; set; }

    public string? LastUpdateby { get; set; }

    public DateTime? LastUpdatedate { get; set; }

    public decimal? OrdMileageAdjPct { get; set; }

    public string? OrdTrlrentinv { get; set; }

    public int? OrdRevenuePayFix { get; set; }

    public decimal? OrdRevenuePay { get; set; }

    public string? OrdReservedNumber { get; set; }

    public int? OrdCustomsDocument { get; set; }

    public short? OrdChargeTypeLh { get; set; }

    public byte OrdNoautosplit { get; set; }

    public byte OrdNoautotransfer { get; set; }

    public DateTime? OrdCompleteStamp { get; set; }

    public decimal? OrdTotalloadingmeters { get; set; }

    public string? OrdTotalloadingmetersunit { get; set; }

    public string OrdEntryport { get; set; } = null!;

    public string OrdExitport { get; set; } = null!;

    public double? OrdCommoditiesWeight { get; set; }

    public string? OrdIntermodal { get; set; }

    public decimal? OrdDimfactor { get; set; }

    public int? ExternalId { get; set; }

    public string? ExternalType { get; set; }

    public int? OrdUnlockKey { get; set; }

    public string? OrdTrlConfiguration { get; set; }

    public string? OrdOriginZip { get; set; }

    public string? OrdDestZip { get; set; }

    public string? OrdRateMileagetable { get; set; }

    public decimal? OrdTollCost { get; set; }

    public DateTime? OrdTollCostUpdateDate { get; set; }

    public string? OrdRaildest { get; set; }

    public string? OrdRailpoolid { get; set; }

    public string? OrdTrailer2 { get; set; }

    public int? OrdOdmetermilesMtid { get; set; }

    public string? OrdRoute { get; set; }

    public DateTime? OrdRouteEffcDate { get; set; }

    public DateTime? OrdRouteExpDate { get; set; }

    public string? OrdOrderSource { get; set; }

    public string? OrdEdipurpose { get; set; }

    public string? OrdEdiuseraction { get; set; }

    public byte? OrdEdistate { get; set; }

    public string? OrdNoRecalcMiles { get; set; }

    public string? OrdEditradingpartner { get; set; }

    public string? OrdEdideclinereason { get; set; }

    public DateTime? OrdMiscdate1 { get; set; }

    public string? OrdCarrier { get; set; }

    public string OrdPydStatus1 { get; set; } = null!;

    public string OrdPydStatus2 { get; set; } = null!;

    public string? OrdPin { get; set; }

    public string? OrdAccounttype { get; set; }

    public string? OrdBatchrateeligibility { get; set; }

    public string? OrdBatchratestatus { get; set; }

    public int? OrdOdometerStart { get; set; }

    public int? OrdOdometerEnd { get; set; }

    public decimal? OrdBillmiles { get; set; }

    public decimal? OrdPaymiles { get; set; }

    public decimal? OrdStandardhours { get; set; }

    public string? OrdPreventexternalupdate { get; set; }

    public int? OrdJobOrdered { get; set; }

    public int? OrdJobRemaining { get; set; }

    public string? OrdShortcomment { get; set; }

    public DateTime? OrdLastratedate { get; set; }

    public int? OrdManualeventcallminutes { get; set; }

    public int? OrdManualcheckcallminutes { get; set; }

    public string? SvManuExportFlag { get; set; }

    public string? OrdCbp { get; set; }

    public string? OrdCyclicDspEnabled { get; set; }

    public string? OrdPreassignAckRequired { get; set; }

    public string? OrdAncNumber { get; set; }

    public string? OrdGvwUnit { get; set; }

    public decimal? OrdGvwAmt { get; set; }

    public string? OrdGvwAdjstdUnit { get; set; }

    public decimal? OrdGvwAdjstdAmt { get; set; }

    public string? OrdBelongsTo { get; set; }

    public string? OrdThirdpartytype3 { get; set; }

    public double OrdThirdpartySplitPercent { get; set; }

    public string? OrdThirdpartySplit { get; set; }

    public string? OrdChassis { get; set; }

    public string? OrdChassis2 { get; set; }

    public int? OrdShowasconsigneeDist { get; set; }

    public string? OrdUseShowasconsigneeDist { get; set; }

    public string? OrdNomincharges { get; set; }

    public int? CarKey { get; set; }

    public string? GstReq { get; set; }

    public string? QstReq { get; set; }

    public string? OrdCarrierchangecode { get; set; }

    public string? OrdExtequipAutomatch { get; set; }

    public string? IvaReq { get; set; }

    public decimal? OrdBrokerPercent { get; set; }

    public decimal? OrdTargetMargin { get; set; }

    public string? OrdPaystatusOverride { get; set; }

    public string? HstReq { get; set; }

    public int? RowsecRsrvId { get; set; }

    public DateTime? OrdCustomdate { get; set; }

    public string? OrdTimezone { get; set; }

    public DateTime? OrdDatepromised { get; set; }

    public byte? OrdEdistatePrior { get; set; }

    public string? OrdPalletType { get; set; }

    public int? OrdPalletCount { get; set; }

    public string? OrdRailramporig { get; set; }

    public string? OrdRailrampdest { get; set; }

    public string? OrdRatemode { get; set; }

    public string? OrdServicelevel { get; set; }

    public int? OrdServicedays { get; set; }

    public string? OrdOverCreditLimitApproved { get; set; }

    public string? OrdOverCreditLimitApprovedBy { get; set; }

    public DateTime? OrdInvoiceEffectivedate { get; set; }

    public string? OrdReviewneeded { get; set; }

    public string? OrdDelRptSent { get; set; }

    public string? OrdReviewed { get; set; }

    public string? OrdReviewedby { get; set; }

    public DateTime? OrdRevieweddate { get; set; }

    public string? RecurringJobFlag { get; set; }

    public string? OrdRoutename { get; set; }

    public string? OrdRemark2 { get; set; }

    public DateTime? Payrollcloseddate { get; set; }

    public DateTime? Billingcloseddate { get; set; }

    public DateTime? OrdBillingUsedate { get; set; }

    public string? OrdBillingUsedateSetting { get; set; }

    public string? OrdOverrideStopType { get; set; }

    public string? OrdChecklisttype { get; set; }

    public string? OrdMastermatchpending { get; set; }

    public string? OrdRailschedulecascadepending { get; set; }

    public string? OrdImportexport { get; set; }

    public string? OrdPendinglegstatusupdate { get; set; }

    public string? OrdSubmode { get; set; }

    public bool? OrdJobFreightbased { get; set; }

    public string? OrdApproved { get; set; }

    public string? OrdEdiaccepttext { get; set; }

    public DateTime? OrdTriprptLastRundate { get; set; }

    public string? OrdAppEqcodes { get; set; }
}
