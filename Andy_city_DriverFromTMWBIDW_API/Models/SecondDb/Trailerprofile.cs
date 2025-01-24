using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models.SecondDb;

public partial class Trailerprofile
{
    public string TrlNumber { get; set; } = null!;

    public string TrlOwner { get; set; } = null!;

    public string? TrlMake { get; set; }

    public string? TrlModel { get; set; }

    public int? TrlCurrenthub { get; set; }

    public string? TrlType1 { get; set; }

    public string? TrlType2 { get; set; }

    public string? TrlType3 { get; set; }

    public string? TrlType4 { get; set; }

    public int? TrlYear { get; set; }

    public DateTime? TrlStartdate { get; set; }

    public DateTime? TrlRetiredate { get; set; }

    public double? TrlMpg { get; set; }

    public string? TrlCompany { get; set; }

    public string? TrlFleet { get; set; }

    public string? TrlDivision { get; set; }

    public string? TrlTerminal { get; set; }

    public string? CmpId { get; set; }

    public int? CtyCode { get; set; }

    public string? TrlIlt { get; set; }

    public int? TrlMtwgt { get; set; }

    public int? TrlGrosswgt { get; set; }

    public short? TrlAxles { get; set; }

    public double? TrlHt { get; set; }

    public double? TrlLen { get; set; }

    public double? TrlWdth { get; set; }

    public string? TrlLicstate { get; set; }

    public string? TrlLicnum { get; set; }

    public string? TrlStatus { get; set; }

    public string? TrlSerial { get; set; }

    public DateTime? TrlDateacquired { get; set; }

    public double? TrlOrigcost { get; set; }

    public double? TrlOpercostmile { get; set; }

    public DateTime? TrlSchDate { get; set; }

    public string? TrlSchCmpId { get; set; }

    public int? TrlSchCity { get; set; }

    public string? TrlSchStatus { get; set; }

    public DateTime? TrlAvailDate { get; set; }

    public string? TrlAvailCmpId { get; set; }

    public int? TrlAvailCity { get; set; }

    public string? TrlFixRecord { get; set; }

    public int? TrlLastStop { get; set; }

    public string? TrlMisc1 { get; set; }

    public string? TrlMisc2 { get; set; }

    public string? TrlMisc3 { get; set; }

    public string? TrlMisc4 { get; set; }

    public string TrlId { get; set; } = null!;

    public int? TrlCurMileage { get; set; }

    public string? TrlBmpPathname { get; set; }

    public byte[]? Timestamp { get; set; }

    public string? TrlActgType { get; set; }

    public string? TrlIltScac { get; set; }

    public string? TrlUpdatedby { get; set; }

    public DateTime? TrlUpdateon { get; set; }

    public double? TrlTareweight { get; set; }

    public double? TrlKpToAxle1 { get; set; }

    public double? TrlAxle1ToAxle2 { get; set; }

    public double? TrlAxle2ToAxle3 { get; set; }

    public double? TrlAxle3ToAxle4 { get; set; }

    public int? TrlComprt1SizeWet { get; set; }

    public int? TrlComprt2SizeWet { get; set; }

    public int? TrlComprt3SizeWet { get; set; }

    public int? TrlComprt4SizeWet { get; set; }

    public int? TrlComprt5SizeWet { get; set; }

    public int? TrlComprt6SizeWet { get; set; }

    public string? TrlComprt1UomWet { get; set; }

    public string? TrlComprt2UomWet { get; set; }

    public string? TrlComprt3UomWet { get; set; }

    public string? TrlComprt4UomWet { get; set; }

    public string? TrlComprt5UomWet { get; set; }

    public string? TrlComprt6UomWet { get; set; }

    public string? TrlComprt1Bulkhead { get; set; }

    public string? TrlComprt2Bulkhead { get; set; }

    public string? TrlComprt3Bulkhead { get; set; }

    public string? TrlComprt4Bulkhead { get; set; }

    public string? TrlComprt5Bulkhead { get; set; }

    public string? TrlTareweightUom { get; set; }

    public string? TrlKpToAxle1Uom { get; set; }

    public string? TrlAxle1ToAxle2Uom { get; set; }

    public string? TrlAxle2ToAxle3Uom { get; set; }

    public string? TrlAxle3ToAxle4Uom { get; set; }

    public DateTime? TrlCreatedate { get; set; }

    public string? TrlPupid { get; set; }

    public double? TrlAxle4ToAxle5 { get; set; }

    public string? TrlAxle4ToAxle5Uom { get; set; }

    public double? TrlLastaxleToRear { get; set; }

    public string? TrlLastaxleToRearUom { get; set; }

    public double? TrlNoseToKp { get; set; }

    public string? TrlNoseToKpUom { get; set; }

    public int? TrlTotalNoOfCompartments { get; set; }

    public double? TrlTotalTrailerSizeWet { get; set; }

    public string? TrlUomWet { get; set; }

    public double? TrlTotalTrailerSizeDry { get; set; }

    public string? TrlUomDry { get; set; }

    public int? TrlComprt1SizeDry { get; set; }

    public int? TrlComprt2SizeDry { get; set; }

    public int? TrlComprt3SizeDry { get; set; }

    public int? TrlComprt4SizeDry { get; set; }

    public int? TrlComprt5SizeDry { get; set; }

    public int? TrlComprt6SizeDry { get; set; }

    public string? TrlComprt1UomDry { get; set; }

    public string? TrlComprt2UomDry { get; set; }

    public string? TrlComprt3UomDry { get; set; }

    public string? TrlComprt4UomDry { get; set; }

    public string? TrlComprt5UomDry { get; set; }

    public string? TrlComprt6UomDry { get; set; }

    public double? TrlBulkheadComprt1Thick { get; set; }

    public double? TrlBulkheadComprt2Thick { get; set; }

    public double? TrlBulkheadComprt3Thick { get; set; }

    public double? TrlBulkheadComprt4Thick { get; set; }

    public double? TrlBulkheadComprt5Thick { get; set; }

    public string? TrlBulkheadComprt1ThickUom { get; set; }

    public string? TrlBulkheadComprt2ThickUom { get; set; }

    public string? TrlBulkheadComprt3ThickUom { get; set; }

    public string? TrlBulkheadComprt4ThickUom { get; set; }

    public string? TrlBulkheadComprt5ThickUom { get; set; }

    public string? TrlQuickentry { get; set; }

    public string? TrlWashStatus { get; set; }

    public string? TrlManualupdate { get; set; }

    public DateTime? TrlExp1Date { get; set; }

    public DateTime? TrlExp2Date { get; set; }

    public string? TrlLastCmd { get; set; }

    public int? TrlLastCmdOrd { get; set; }

    public DateTime? TrlLastCmdDate { get; set; }

    public int? TrlPalletcount { get; set; }

    public string? TrlCustomerFlag { get; set; }

    public string? TrlBilltoParent { get; set; }

    public string? TrlBookedRevtype1 { get; set; }

    public string? TrlNextEvent { get; set; }

    public string? TrlNextCmpId { get; set; }

    public int? TrlNextCity { get; set; }

    public string? TrlNextState { get; set; }

    public string? TrlNextRegion1 { get; set; }

    public string? TrlNextRegion2 { get; set; }

    public string? TrlNextRegion3 { get; set; }

    public string? TrlNextRegion4 { get; set; }

    public string? TrlPriorEvent { get; set; }

    public string? TrlPriorCmpId { get; set; }

    public int? TrlPriorCity { get; set; }

    public string? TrlPriorState { get; set; }

    public string? TrlPriorRegion1 { get; set; }

    public string? TrlPriorRegion2 { get; set; }

    public string? TrlPriorRegion3 { get; set; }

    public string? TrlPriorRegion4 { get; set; }

    public string? TrlAccessorylist { get; set; }

    public int TrlNewused { get; set; }

    public string TrlGpClass { get; set; } = null!;

    public string? TrlWorksheetComment1 { get; set; }

    public string? TrlWorksheetComment2 { get; set; }

    public string? TrlLoadingClass { get; set; }

    public double? TrlAxlgrp1Tarewgt { get; set; }

    public double? TrlAxlgrp1Grosswgt { get; set; }

    public double? TrlAxlgrp2Tarewgt { get; set; }

    public double? TrlAxlgrp2Grosswgt { get; set; }

    public DateTime? TrlExp1Enddate { get; set; }

    public DateTime? TrlExp2Enddate { get; set; }

    public string? TrlGpsDesc { get; set; }

    public DateTime? TrlGpsDate { get; set; }

    public int? TrlGpsLatitude { get; set; }

    public int? TrlGpsLongitude { get; set; }

    public int? TrlGpsOdometer { get; set; }

    public decimal? TrlLifetimemileage { get; set; }

    public string? TrlBranch { get; set; }

    public double? TrlHeight { get; set; }

    public double? TrlWidth { get; set; }

    public string? TrlLiccountry { get; set; }

    public string? TrlAceid { get; set; }

    public string? TrlAceidtype { get; set; }

    public string? TrlEmail { get; set; }

    public string TrlEquipmenttype { get; set; } = null!;

    public string? TrlPrefix { get; set; }

    public string? TrlPriorCmpOthertype1 { get; set; }

    public string? TrlNextCmpOthertype1 { get; set; }

    public decimal? TrlCapacityWgt { get; set; }

    public decimal? TrlCapacityLdm { get; set; }

    public int? RowsecRsrvId { get; set; }

    public int? TrlMobilecommaccount { get; set; }

    public string? TrlAppEqcodes { get; set; }

    public string? TrlUnassignedReasoncode { get; set; }

    public string? TrlUnassignedComments { get; set; }

    public decimal? TrlDwelltime { get; set; }

    public string? TrlValiditychks { get; set; }

    public string? TrlIsoCode { get; set; }

    public int? PayScheduleId { get; set; }

    public double? TrlGpsHeading { get; set; }

    public int? TrlGpsSpeed { get; set; }

    public string? TrlUseRfid { get; set; }

    public string? TrlRfidTag { get; set; }

    public double? TrlCmpt1Temp { get; set; }

    public double? TrlCmpt2Temp { get; set; }

    public double? TrlCmpt3Temp { get; set; }

    public double? TrlCmpt4Temp { get; set; }

    public double? TrlCmpt5Temp { get; set; }

    public double? TrlCmpt1Setpoint { get; set; }

    public double? TrlCmpt2Setpoint { get; set; }

    public double? TrlCmpt3Setpoint { get; set; }

    public double? TrlCmpt4Setpoint { get; set; }

    public double? TrlCmpt5Setpoint { get; set; }

    public double? TrlDischargetemp { get; set; }

    public double? TrlAmbienttemp { get; set; }

    public string? TrlAlarmstate { get; set; }

    public double? TrlCmpt1DesiredSetpoint { get; set; }

    public double? TrlCmpt2DesiredSetpoint { get; set; }

    public double? TrlCmpt3DesiredSetpoint { get; set; }

    public double? TrlCmpt4DesiredSetpoint { get; set; }

    public double? TrlCmpt5DesiredSetpoint { get; set; }

    public string? TrlDesiredSetpointsSetby { get; set; }

    public string? TrlReeferpower { get; set; }

    public string? TrlMcommId { get; set; }

    public string? TrlMcommType { get; set; }

    public int? TrlReeferhist1 { get; set; }

    public int? TrlReeferhist2 { get; set; }

    public string? TrlUseGeofencing { get; set; }

    public string? TrlAmsType { get; set; }

    public string? OriginDestinationOption { get; set; }

    public string? TrlCarrier { get; set; }

    public string? TrlDoubleBulkHead { get; set; }

    public string? TrlDischargeSide { get; set; }

    public string? TrlPumpUnit { get; set; }
}
