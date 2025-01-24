using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models;

public partial class AndyIsaacApiActivity
{
    public long Id { get; set; }

    public DateTime? Calldate { get; set; }

    public string? ActivityRecordId { get; set; }

    public int? ActivityDutyType { get; set; }

    public string? ActivityCodeName { get; set; }

    public int? ActivityCode { get; set; }

    public int? ActivityId { get; set; }

    public string? AddressName { get; set; }

    public string? AddressStreet { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressDistrict { get; set; }

    public string? AddressCountry { get; set; }

    public string? AddressPostalCode { get; set; }

    public decimal? AddressLatitude { get; set; }

    public decimal? AddressLongitude { get; set; }

    public DateTime? ActivityDate { get; set; }

    public int? DriverNo { get; set; }

    public string? VehicleNo { get; set; }

    public string? Form { get; set; }

    public decimal? OdometerKm { get; set; }

    public string? WorkflowActivityId { get; set; }

    public string? TripId { get; set; }

    public string? TripIdNote { get; set; }

    public string? EquipmentNameList { get; set; }
}
