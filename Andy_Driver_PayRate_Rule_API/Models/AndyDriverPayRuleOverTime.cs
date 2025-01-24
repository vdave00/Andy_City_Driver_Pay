using System;
using System.Collections.Generic;

namespace Andy_Driver_PayRate_Rule_API.Models;

public partial class AndyDriverPayRuleOverTime
{
    public string PayRateName { get; set; } = null!;

    public decimal? Formula { get; set; }

    public string? PayRateForumula { get; set; }
}
