using System;
using System.Collections.Generic;

namespace Andy_city_DriverFromTMWBIDW_API.Models.SecondDb;

public partial class Payschedulesdetail
{
    public int PsdId { get; set; }

    public DateTime? PsdDate { get; set; }

    public string? PsdStatus { get; set; }

    public int PshId { get; set; }

    public string? PsdBatchId { get; set; }

    public string? PsdBatchStatus { get; set; }

    public DateTime? PsdChkissuedate { get; set; }

    public byte? PsdApplicableMonth { get; set; }

    public int? PsdApplicableYear { get; set; }

    public string? SdmItemcodeExcludeInd { get; set; }

    public string? SdmItemcodeExcludeList { get; set; }
}
