using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models.SecondDb;

public partial class AndyDriverPayRate
{
    public string? DriverId { get; set; }

    public string? FleetCompanyId { get; set; }

    public decimal? RegularRateDayShift { get; set; }

    public decimal? RegularRateEveShift { get; set; }

    public decimal? RegularRateNightShift { get; set; }

    public decimal? OverTimeRateDayShift { get; set; }

    public decimal? OverTimeRateEveShift { get; set; }

    public decimal? OverTimeRateNightShift { get; set; }

    public int AndyDriverPayRateId { get; set; }

    public decimal? RatePerMileage { get; set; }

    public decimal? WeekendRate { get; set; }

    public DateOnly? EffectiveDateTo { get; set; }

    public DateOnly? EffectiveDateFrom { get; set; }

    public bool? IsActive { get; set; }

    public string? UpdateBy { get; set; }

    public string? DriverTyper { get; set; }

    public decimal? OverTimeRateWeekendShift { get; set; }
}
