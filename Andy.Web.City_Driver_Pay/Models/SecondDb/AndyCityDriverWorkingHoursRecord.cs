using System;
using System.Collections.Generic;

namespace Andy.Web.City_Driver_Pay.Models.SecondDb;

public partial class AndyCityDriverWorkingHoursRecord
{
    public string? DriverId { get; set; }

    public string? MoveNumber { get; set; }

    public string? OrderNumber { get; set; }

    public DateOnly? DateOfWork { get; set; }

    public string? LegNumber { get; set; }

    public string? Tractor { get; set; }

    public string? Trailer { get; set; }

    public int? Seconds { get; set; }

    public decimal? CalculateHours { get; set; }

    public decimal? PaidHours { get; set; }

    public string? Notes { get; set; }

    public decimal? PayRate { get; set; }

    public decimal? TotalPay { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddDate { get; set; }

    public string? OrderNumberTmw { get; set; }

    public string? Division { get; set; }
}
