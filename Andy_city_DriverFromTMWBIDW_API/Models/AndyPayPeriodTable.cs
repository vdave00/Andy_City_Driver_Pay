using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models;

public partial class AndyPayPeriodTable
{
    public int PayPeriodId { get; set; }

    public DateOnly WeekStartDate { get; set; }

    public DateOnly WeekEndDate { get; set; }

    public DateOnly? PayPeriodPayDate { get; set; }

    public DateTime? CreatedDate { get; set; }
}
