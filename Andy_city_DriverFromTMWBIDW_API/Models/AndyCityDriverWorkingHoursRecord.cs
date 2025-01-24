using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models;

public partial class AndyCityDriverWorkingHoursRecord
{
    public int Id { get; set; }

    public string? DriverId { get; set; }

    public string? OrderNumber { get; set; }

    public string? MoveNumber { get; set; }

    public DateOnly? DateOfWork { get; set; }

    public string? Tractor { get; set; }

    public string? Trailer { get; set; }

    public int? Seconds { get; set; }

    public DateTime? AddDate { get; set; }

    public string? Km { get; set; }

    public double? CalculateHours { get; set; }

    public double? PaidHours { get; set; }

    public string? Notes { get; set; }

    public double? PayRate { get; set; }

    public double? TotalPay { get; set; }

    public string? AddedBy { get; set; }

    public string? OrderNumberTmw { get; set; }

    public string? Division { get; set; }

    public string? LegNumber { get; set; }
}
