using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models;

public partial class AndyDriverWorkbookRecordV1
{
    public int Id { get; set; }

    public int? DriverNo { get; set; }

    public string? Vehicleno { get; set; }

    public string? ActivityCodeName { get; set; }

    public string? Location { get; set; }

    public string? AddressCountry { get; set; }

    public string? AddressPostalCode { get; set; }

    public decimal? AddressLatitude { get; set; }

    public decimal? AddressLongitude { get; set; }

    public DateTime? ActivityDate { get; set; }

    public DateOnly? Dateonly { get; set; }

    public string? Form { get; set; }

    public decimal? OdometerKm { get; set; }

    public int? TripId { get; set; }

    public int? Maxid { get; set; }

    public string? TripNo { get; set; }

    public string? Reference { get; set; }

    public string? Note { get; set; }

    public int? NoteOrdernum { get; set; }

    public string? NoteMovenum { get; set; }

    public string? NoteDriver1 { get; set; }

    public string? NoteDriver2 { get; set; }

    public string? NoteTractor { get; set; }

    public string? NoteTrailer1 { get; set; }

    public string? NoteTrailer2 { get; set; }

    public string? TrlFleet { get; set; }

    public string? Mysecond2 { get; set; }

    public string? Mysecond { get; set; }

    public string? Miles { get; set; }

    public string? Myrow { get; set; }

    public string? Myrow2 { get; set; }

    public string? MppId { get; set; }

    public string? MppLastfirst { get; set; }

    public int? OrderMins { get; set; }

    public double? AvgSpeed { get; set; }

    public string? ZoneType { get; set; }

    public string? ZoneName { get; set; }

    public string? OrdRevtype2 { get; set; }

    public double? TotalHrsRaw { get; set; }

    public string? TotalHrs { get; set; }

    public string? Notes { get; set; }

    public string? FirstPage { get; set; }
}
