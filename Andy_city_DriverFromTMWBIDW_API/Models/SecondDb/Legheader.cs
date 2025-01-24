using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models.SecondDb;

public partial class Legheader
{
    public int LghNumber { get; set; }

    public int? LghFirstlegnumber { get; set; }

    public int? LghLastlegnumber { get; set; }

    public int? LghDrvtripnumber { get; set; }

    public double? LghCost { get; set; }

    public double? LghRevenue { get; set; }

    public int? LghOdometerstart { get; set; }

    public int? LghOdometerend { get; set; }

    public short? LghMilesshortest { get; set; }

    public short? LghMilespractical { get; set; }

    public double? LghAllocfactor { get; set; }

    public DateTime? LghStartdate { get; set; }

    public DateTime? LghEnddate { get; set; }

    public int? LghStartcity { get; set; }

    public int? LghEndcity { get; set; }

    public string? LghStartregion1 { get; set; }

    public string? LghEndregion1 { get; set; }

    public string? LghStartstate { get; set; }

    public string? LghEndstate { get; set; }

    public string? LghOutstatus { get; set; }

    public int? LghStartlat { get; set; }

    public int? LghStartlong { get; set; }

    public int? LghEndlat { get; set; }

    public int? LghEndlong { get; set; }

    public string? LghClass1 { get; set; }

    public string? LghClass2 { get; set; }

    public string? LghClass3 { get; set; }

    public string? LghClass4 { get; set; }

    public int? StpNumberStart { get; set; }

    public int? StpNumberEnd { get; set; }

    public string? CmpIdStart { get; set; }

    public string? CmpIdEnd { get; set; }

    public string? LghStartregion2 { get; set; }

    public string? LghStartregion3 { get; set; }

    public string? LghStartregion4 { get; set; }

    public string? LghEndregion2 { get; set; }

    public string? LghEndregion3 { get; set; }

    public string? LghEndregion4 { get; set; }

    public string? LghInstatus { get; set; }

    public string? LghDriver1 { get; set; }

    public string? LghDriver2 { get; set; }

    public string? LghTractor { get; set; }

    public string? LghPrimaryTrailer { get; set; }

    public int? MovNumber { get; set; }

    public int? FgtNumber { get; set; }

    public string? LghPriority { get; set; }

    public DateTime? LghSchdtearliest { get; set; }

    public DateTime? LghSchdtlatest { get; set; }

    public string? CmdCode { get; set; }

    public string? FgtDescription { get; set; }

    public string? MppTeamleader { get; set; }

    public string? MppFleet { get; set; }

    public string? MppDivision { get; set; }

    public string? MppDomicile { get; set; }

    public string? MppCompany { get; set; }

    public string? MppTerminal { get; set; }

    public string? MppType1 { get; set; }

    public string? MppType2 { get; set; }

    public string? MppType3 { get; set; }

    public string? MppType4 { get; set; }

    public string? TrcCompany { get; set; }

    public string? TrcDivision { get; set; }

    public string? TrcFleet { get; set; }

    public string? TrcTerminal { get; set; }

    public string? TrcType1 { get; set; }

    public string? TrcType2 { get; set; }

    public string? TrcType3 { get; set; }

    public string? TrcType4 { get; set; }

    public int? MfhNumber { get; set; }

    public string? TrlCompany { get; set; }

    public string? TrlFleet { get; set; }

    public string? TrlDivision { get; set; }

    public string? TrlTerminal { get; set; }

    public string? TrlType1 { get; set; }

    public string? TrlType2 { get; set; }

    public string? TrlType3 { get; set; }

    public string? TrlType4 { get; set; }

    public int? OrdHdrnumber { get; set; }

    public byte[]? Timestamp { get; set; }

    public string? LghFueltaxstatus { get; set; }

    public short? LghMtmiles { get; set; }

    public DateTime? LghPrjdate1 { get; set; }

    public int? LghEtamins1 { get; set; }

    public string? LghOutofrouteRouting { get; set; }

    public string? LghType1 { get; set; }

    public decimal? LghAllocRevenue { get; set; }

    public string? LghPrimaryPup { get; set; }

    public double? LghProdHr { get; set; }

    public double? LghTotHr { get; set; }

    public double? LghLdUnldTime { get; set; }

    public double? LghLoadTime { get; set; }

    public string? LghStartctyNmstct { get; set; }

    public string? LghEndctyNmstct { get; set; }

    public string? LghCarrier { get; set; }

    public string? LghActive { get; set; }

    public DateTime? LghEnddateArrival { get; set; }

    public DateTime? LghDspDate { get; set; }

    public DateTime? LghGeoDate { get; set; }

    public string? LghNexttrailer1 { get; set; }

    public string? LghNexttrailer2 { get; set; }

    public int? LghEtamilestofinal { get; set; }

    public int? LghEtamintofinal { get; set; }

    public string? LghSplitFlag { get; set; }

    public string? LghCreatedby { get; set; }

    public DateTime? LghCreatedon { get; set; }

    public string? LghCreateapp { get; set; }

    public string? LghUpdatedby { get; set; }

    public DateTime? LghUpdatedon { get; set; }

    public string? LghUpdateapp { get; set; }

    public short? LghFeetavailable { get; set; }

    public DateTime? LghRstartdate { get; set; }

    public DateTime? LghRenddate { get; set; }

    public int? LghRstartcity { get; set; }

    public int? LghRendcity { get; set; }

    public string? LghRstartregion1 { get; set; }

    public string? LghRendregion1 { get; set; }

    public string? LghRstartstate { get; set; }

    public string? LghRendstate { get; set; }

    public int? LghRstartlat { get; set; }

    public int? LghRstartlong { get; set; }

    public int? LghRendlat { get; set; }

    public int? LghRendlong { get; set; }

    public int? StpNumberRstart { get; set; }

    public int? StpNumberRend { get; set; }

    public string? CmpIdRstart { get; set; }

    public string? CmpIdRend { get; set; }

    public string? LghRstartregion2 { get; set; }

    public string? LghRstartregion3 { get; set; }

    public string? LghRstartregion4 { get; set; }

    public string? LghRendregion2 { get; set; }

    public string? LghRendregion3 { get; set; }

    public string? LghRendregion4 { get; set; }

    public string? LghRstartctyNmstct { get; set; }

    public string? LghRendctyNmstct { get; set; }

    public DateTime? CanCapExpires { get; set; }

    public DateTime? CanLdExpires { get; set; }

    public DateTime? LghDispatchdate { get; set; }

    public string? LghAssetLock { get; set; }

    public DateTime? LghAssetLockDtm { get; set; }

    public string? LghAssetLockUser { get; set; }

    public int? DrvplanNumber { get; set; }

    public string? LghType2 { get; set; }

    public string? LghTmStatus { get; set; }

    public int? LghTourNumber { get; set; }

    public DateTime? LghActtransferdate { get; set; }

    public decimal? LghFuelburned { get; set; }

    public decimal? LghActualmiles { get; set; }

    public decimal? LghTriphours { get; set; }

    public DateTime? LghFueltaxstatusdate { get; set; }

    public string? LghLoadOrigin { get; set; }

    public string? LghComment { get; set; }

    public int? LghMiles { get; set; }

    public double? LghLinehaul { get; set; }

    public byte LghNoautosplit { get; set; }

    public byte LghNoautotransfer { get; set; }

    public double? LghOrdCharge { get; set; }

    public double? LghActWeight { get; set; }

    public double? LghEstWeight { get; set; }

    public double? LghTotWeight { get; set; }

    public string? LghReftype { get; set; }

    public string? LghRefnum { get; set; }

    public string? LghMaxWeightExceeded { get; set; }

    public string? LghType3 { get; set; }

    public string? LghType4 { get; set; }

    public int? LghManuallysettypeclass { get; set; }

    public int? LghTmstatusstopnumber { get; set; }

    public int LghDetstatus { get; set; }

    public string? LghEtaCmpList { get; set; }

    public string? OrdBillto { get; set; }

    public DateTime? LghEtacalcdate { get; set; }

    public string? LghEtacomment { get; set; }

    public string? LghWashplan { get; set; }

    public string? LghHzdCmdClass { get; set; }

    public string? LghActtransfer { get; set; }

    public string? LghOriginzip { get; set; }

    public string? LghDestzip { get; set; }

    public string? Lgh204status { get; set; }

    public string? LghBookedRevtype1 { get; set; }

    public string? LghRoute { get; set; }

    public string? LghOrderSource { get; set; }

    public string? LghPermitStatus { get; set; }

    public DateTime? Lgh204date { get; set; }

    public string? LghTrcComment { get; set; }

    public string? LghAceStatus { get; set; }

    public string? LghType5 { get; set; }

    public int? ShiftSsId { get; set; }

    public DateTime? LghShiftdate { get; set; }

    public string? LghShiftnumber { get; set; }

    public DateTime? LghMppTypeEditdatetime { get; set; }

    public string? Mpp2Type1 { get; set; }

    public string? Mpp2Type2 { get; set; }

    public string? Mpp2Type3 { get; set; }

    public string? Mpp2Type4 { get; set; }

    public decimal? LghCarTotalcharge { get; set; }

    public string? LghChassis { get; set; }

    public string? LghChassis2 { get; set; }

    public string? LghRecommendedCarId { get; set; }

    public string? LghPermitnumbers { get; set; }

    public string? LghPermitby { get; set; }

    public DateTime? LghPermitdate { get; set; }

    public DateTime? LghEtaEstStartdate { get; set; }

    public DateTime? LghEtaEstEnddate { get; set; }

    public DateTime? LghEtaNextPickup { get; set; }

    public DateTime? LghEtaNextDrop { get; set; }

    public string? Lgh204Tradingpartner { get; set; }

    public int? LghTotalMovBillMiles { get; set; }

    public int? LghTotalMovMiles { get; set; }

    public string? LghMileOverageMessage { get; set; }

    public decimal? LghCarRate { get; set; }

    public decimal? LghCarCharge { get; set; }

    public decimal? LghCarAccessorials { get; set; }

    public string? LghSpotRateUpdatedby { get; set; }

    public DateTime? LghSpotRateUpdateddt { get; set; }

    public string? LghSpotRate { get; set; }

    public string? LghShipStatus { get; set; }

    public decimal? LghProtectedRate { get; set; }

    public decimal? LghAvgRate { get; set; }

    public string? LghEdiCounter { get; set; }

    public decimal? LghAccSo1 { get; set; }

    public decimal? LghAccSo2 { get; set; }

    public decimal? LghAccSo3 { get; set; }

    public decimal? LghAccSo4 { get; set; }

    public decimal? LghAccSo5 { get; set; }

    public decimal? LghAccSo6 { get; set; }

    public DateTime? LghRateDt { get; set; }

    public decimal? LghAccFsc { get; set; }

    public string? LghRateError { get; set; }

    public string? LghRateErrorDesc { get; set; }

    public string? LghFaxemailCreated { get; set; }

    public int? LghExternalratingMiles { get; set; }

    public int? LghRtdId { get; set; }

    public string? LghPrevSegStatus { get; set; }

    public DateTime? LghPrevSegStatusLastUpdated { get; set; }

    public string? LghRaildispatchstatus { get; set; }

    public int? Lgh204validate { get; set; }

    public long? MaTransactionId { get; set; }

    public int? MaTourNumber { get; set; }

    public byte? MaTourSequence { get; set; }

    public string? MaMppId { get; set; }

    public string? MaTrcNumber { get; set; }

    public string? LghDolly { get; set; }

    public string? LghDolly2 { get; set; }

    public string? LghTrailer3 { get; set; }

    public string? LghTrailer4 { get; set; }

    public int? LghRailtemplatedetailId { get; set; }

    public string? TrcTeamleader { get; set; }

    public string? LghOptimizestatus { get; set; }

    public int? LghOptimizedrouteid { get; set; }

    public string? LghOtherStatus1 { get; set; }

    public string? LghOtherStatus2 { get; set; }

    public string? LghEtaalert1 { get; set; }

    public string? LghRatemode { get; set; }

    public string? LghServicelevel { get; set; }

    public int? LghServicedays { get; set; }

    public string? RailServiceLevel { get; set; }

    public decimal? LghPlannedhours { get; set; }

    public string? LghDirectRouteStatus1 { get; set; }

    public string? LghCarAccessorialCodes { get; set; }

    public string? LghCarAccessorialRates { get; set; }

    public DateTime? LghOptimizationdate { get; set; }

    public double? LghAutoloadmaxgvw { get; set; }

    public DateTime? LghPlandate { get; set; }

    public int? LghLaneid { get; set; }

    public string? LghExtrainfo1 { get; set; }

    public string? LghExtrainfo2 { get; set; }

    public string? LghExtrainfo3 { get; set; }

    public int? LghRailscheduleId { get; set; }

    public decimal? LghTriphours2 { get; set; }

    public string? LghPayTermCode { get; set; }

    public string? LghOpCode { get; set; }
}
