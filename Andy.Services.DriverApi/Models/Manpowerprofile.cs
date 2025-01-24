using System;
using System.Collections.Generic;

namespace Andy.Services.DriverApi.Models;

public partial class Manpowerprofile
{
    public string MppId { get; set; } = null!;

    public string? MppType { get; set; }

    public string? MppTractornumber { get; set; }

    public string? MppOtherid { get; set; }

    public string? MppEmployedby { get; set; }

    public string? MppFirstname { get; set; }

    public string? MppMiddlename { get; set; }

    public string? MppLastname { get; set; }

    public string? MppSsn { get; set; }

    public string? MppAddress1 { get; set; }

    public string? MppAddress2 { get; set; }

    public int? MppCity { get; set; }

    public string? MppState { get; set; }

    public string? MppZip { get; set; }

    public DateTime? MppHiredate { get; set; }

    public DateTime? MppSenioritydate { get; set; }

    public string? MppLicensestate { get; set; }

    public string? MppLicenseclass { get; set; }

    public string? MppLicensenumber { get; set; }

    public DateTime? MppDateofbirth { get; set; }

    public string? MppCurrentphone { get; set; }

    public string? MppAlternatephone { get; set; }

    public string? MppHomephone { get; set; }

    public string? MppType1 { get; set; }

    public string? MppType2 { get; set; }

    public string? MppType3 { get; set; }

    public string? MppType4 { get; set; }

    public string? MppCurrency { get; set; }

    public string? MppPayto { get; set; }

    public int? MppSinglemilerate { get; set; }

    public int? MppTeammilerate { get; set; }

    public decimal? MppHourlyrate { get; set; }

    public int? MppRevenuerate { get; set; }

    public string? MppTeamleader { get; set; }

    public string? MppFleet { get; set; }

    public string? MppDivision { get; set; }

    public string? MppDomicile { get; set; }

    public string? MppCompany { get; set; }

    public string? MppTerminal { get; set; }

    public string? MppStatus { get; set; }

    public string? MppEmerphone { get; set; }

    public string? MppEmername { get; set; }

    public string? MppVoicemailbox { get; set; }

    public DateTime? MppTerminationdt { get; set; }

    public DateTime? MppAvlDate { get; set; }

    public string? MppAvlCmpId { get; set; }

    public int? MppAvlCity { get; set; }

    public string? MppAvlStatus { get; set; }

    public DateTime? MppPlnDate { get; set; }

    public string? MppPlnCmpId { get; set; }

    public int? MppPlnCity { get; set; }

    public int? MppPlnLgh { get; set; }

    public int? MppAvlLgh { get; set; }

    public string? MppLastfirst { get; set; }

    public byte[]? Timestamp { get; set; }

    public string? MppActgType { get; set; }

    public DateTime? MppLastHome { get; set; }

    public DateTime? MppWantHome { get; set; }

    public string? MppMisc1 { get; set; }

    public string? MppMisc2 { get; set; }

    public string? MppMisc3 { get; set; }

    public string? MppMisc4 { get; set; }

    public string? MppUsecashcard { get; set; }

    public string? MppUpdatedby { get; set; }

    public string? MppBmpPathname { get; set; }

    public DateTime? MppUpdateon { get; set; }

    public DateTime? MppCreatedate { get; set; }

    public string? MppQuickentry { get; set; }

    public string? MppServicerule { get; set; }

    public string? MppGpsDesc { get; set; }

    public DateTime? MppGpsDate { get; set; }

    public int? MppGpsLatitude { get; set; }

    public int? MppGpsLongitude { get; set; }

    public short? MppTravelMinutes { get; set; }

    public short? MppMileDay7 { get; set; }

    public int? MppHomeLatitude { get; set; }

    public int? MppHomeLongitude { get; set; }

    public DateTime? MppLastLogDate { get; set; }

    public double? MppHours1 { get; set; }

    public double? MppHours2 { get; set; }

    public double? MppHours3 { get; set; }

    public string? MppHomeCity { get; set; }

    public DateTime? MppExp1Date { get; set; }

    public DateTime? MppExp2Date { get; set; }

    public string? MppNextEvent { get; set; }

    public string? MppNextCmpId { get; set; }

    public int? MppNextCity { get; set; }

    public string? MppNextState { get; set; }

    public string? MppNextRegion1 { get; set; }

    public string? MppNextRegion2 { get; set; }

    public string? MppNextRegion3 { get; set; }

    public string? MppNextRegion4 { get; set; }

    public string? MppPriorEvent { get; set; }

    public string? MppPriorCmpId { get; set; }

    public int? MppPriorCity { get; set; }

    public string? MppPriorState { get; set; }

    public string? MppPriorRegion1 { get; set; }

    public string? MppPriorRegion2 { get; set; }

    public string? MppPriorRegion3 { get; set; }

    public string? MppPriorRegion4 { get; set; }

    public double? MppDailyhrsest { get; set; }

    public double? MppWeeklyhrsest { get; set; }

    public string? MppLastlogCmpId { get; set; }

    public DateTime? MppLastlogEstdate { get; set; }

    public string? MppLastlogCmpName { get; set; }

    public DateTime? MppEstlogDatetime { get; set; }

    public string? MppPassword { get; set; }

    public string? MppQualificationlist { get; set; }

    public string? MppCountry { get; set; }

    public string MppGpClass { get; set; } = null!;

    public int? MppGpsOdometer { get; set; }

    public short? MppArvDepAllowanceMins { get; set; }

    public byte? MppNbrdependents { get; set; }

    public decimal? MppAvghourlypay { get; set; }

    public decimal? MppAvgperiodpay { get; set; }

    public decimal? MppDailyguarenteedhours { get; set; }

    public decimal? MppPeriodguarenteedhours { get; set; }

    public string? MppComparisonflag { get; set; }

    public DateTime? MppExp1Enddate { get; set; }

    public DateTime? MppExp2Enddate { get; set; }

    public double? MppHours1Week { get; set; }

    public DateTime? MppBidNextStarttime { get; set; }

    public decimal? MppBidNextHours { get; set; }

    public string? MppBidNextType { get; set; }

    public string? MppBidNextRoutestore { get; set; }

    public DateTime? Mpp90daystart { get; set; }

    public string? MppBranch { get; set; }

    public string? MppPerdiemFlag { get; set; }

    public DateTime? MppPerdiemEffDate { get; set; }

    public string? MppAthomeTerminal { get; set; }

    public byte? MppCmpissuedpoints { get; set; }

    public DateTime? MppDrivedate { get; set; }

    public byte? MppYearsofsafedrive { get; set; }

    public DateTime? MppYsdasofdate { get; set; }

    public string? MppMtTypeLoaded { get; set; }

    public string? MppMtTypeEmpty { get; set; }

    public string? MppGender { get; set; }

    public string? MppAceid { get; set; }

    public string? MppAceidtype { get; set; }

    public string? MppProximitycardid { get; set; }

    public string? MppCitizenshipStatus { get; set; }

    public string? MppCitizenshipCountry { get; set; }

    public int? RecId { get; set; }

    public DateTime? MppPtaDate { get; set; }

    public string? MppShiftnumber { get; set; }

    public string? MppEmail { get; set; }

    public DateTime? MppEffDate { get; set; }

    public decimal? MppTuitioncost { get; set; }

    public decimal? MppForgiveAmt { get; set; }

    public decimal? MppForgiveWeekCrdAmt { get; set; }

    public int? MppForgivePeriod { get; set; }

    public decimal? MppContributionAmt { get; set; }

    public int? MppContPeriod { get; set; }

    public decimal? MppContWeekAmt { get; set; }

    public int? MppForgiveCrdNbr { get; set; }

    public int? MppContDedNbr { get; set; }

    public DateTime? MppEligibleStartDate { get; set; }

    public string? MppTuitionAcctStatus { get; set; }

    public DateTime? MppTrainAnvBonusPd { get; set; }

    public decimal? MppForgiveRemainBalance { get; set; }

    public decimal? MppContRemainBalance { get; set; }

    public DateTime? MppTrainAnvBonusEligDate { get; set; }

    public decimal? MppTrainAnvBonusAmt { get; set; }

    public int? MppUpdtForgiveCrdNbr { get; set; }

    public int? MppUpdtContDedNbr { get; set; }

    public decimal? MppUpdtForgiveRemainBalance { get; set; }

    public decimal? MppUpdtContRemainBalance { get; set; }

    public string? MppComment1 { get; set; }

    public string? MppCyclicDspEnabled { get; set; }

    public string? MppPreassignAckRequired { get; set; }

    public DateTime? MppShiftStart { get; set; }

    public DateTime? MppShiftEnd { get; set; }

    public string? MppPriorCmpOthertype1 { get; set; }

    public string? MppNextCmpOthertype1 { get; set; }

    public decimal? MppHrsDblTime { get; set; }

    public string? MppOverrideDefaultOt { get; set; }

    public int? MppCsaScore { get; set; }

    public int? RowsecRsrvId { get; set; }

    public string? MppDriverlogtype { get; set; }

    public string? MppDriverlogGroups { get; set; }

    public string? MppDriverlogTerminal { get; set; }

    public decimal? MppAdvanceRateSolo { get; set; }

    public decimal? MppAdvanceRateTeam { get; set; }

    public DateTime? MppRtwDate { get; set; }

    public double? MppFourteenhrest { get; set; }

    public int? MppHosstatus { get; set; }

    public DateTime? MppHosstatusdate { get; set; }

    public DateTime? MppHosactivityupdateon { get; set; }

    public DateTime? MppGrandfatherDate { get; set; }

    public decimal? GuaranteedPayPromised { get; set; }

    public string? MppSubsistenceEligible { get; set; }

    public string? MppSubsistenceCmpId { get; set; }

    public double? MppSubsistencePayRadius { get; set; }

    public string? MppSubsistenceUseAtHome { get; set; }

    public string? CompensationType { get; set; }

    public int? SthId { get; set; }

    public DateTime? SthStartdate { get; set; }

    public DateTime? MppDefaultShiftstart { get; set; }

    public DateTime? MppDefaultShiftend { get; set; }

    public int? MppMilestonext { get; set; }

    public int? MppNextStopnumber { get; set; }

    public int? MppNextLegnumber { get; set; }

    public DateTime? MppNextStoparrival { get; set; }

    public DateTime? MppLastCalcdate { get; set; }

    public DateTime? MppLastmobilecomm { get; set; }

    public string? MppDefaultShiftpriority { get; set; }

    public string? MppEmployeetype { get; set; }

    public decimal? MppTimeoffbetweenduty { get; set; }

    public string? MppSubsistenceHomeCmpId { get; set; }

    public string? MppTrainee { get; set; }

    public string? MppTrainer { get; set; }

    public int? PayScheduleId { get; set; }

    public double? MppGpsHeading { get; set; }

    public int? MppGpsSpeed { get; set; }

    public string? MppMcommId { get; set; }

    public string? MppMcommType { get; set; }

    public DateTime? MppLastDailyLogsDate { get; set; }

    public DateTime? MppLastDailyLogsConfirmedDate { get; set; }

    public string? MppHosPollRequired { get; set; }

    public string? OriginDestinationOption { get; set; }

    public string? MppCarrier { get; set; }

    public string? MppNote { get; set; }

    public DateTime? MppNoteUpdatedate { get; set; }
}
