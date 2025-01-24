using System;
using System.Collections.Generic;

namespace Andy_Driver_PayRate_Rule_API.Models;

public partial class AndyDriverPayDetail
{
    public string? DriverId { get; set; }

    public string? DriverFname { get; set; }

    public string? DriverMname { get; set; }

    public string? DriverLname { get; set; }

    public string? DriverPayTo { get; set; }

    public decimal? DriverLastPay { get; set; }

    public DateOnly? DriverLastPayDate { get; set; }

    public DateOnly? DriverNewPayEffeciveDate { get; set; }

    public string? TeamLeader { get; set; }
}
