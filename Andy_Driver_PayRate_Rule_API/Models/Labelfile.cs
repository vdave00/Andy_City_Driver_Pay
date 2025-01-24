using System;
using System.Collections.Generic;

namespace Andy_Driver_PayRate_Rule_API.Models;

public partial class Labelfile
{
    public string Labeldefinition { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Abbr { get; set; } = null!;

    public int? Code { get; set; }

    public string? Locked { get; set; }

    public string? Userlabelname { get; set; }

    public string? Edicode { get; set; }

    public byte[]? Timestamp { get; set; }

    public string? Systemcode { get; set; }

    public string? Retired { get; set; }

    public string? InventoryItem { get; set; }

    public string? AcctDb { get; set; }

    public string? IcClearGlnum { get; set; }

    public string? AcctServer { get; set; }

    public string? PytItemcode { get; set; }

    public string? TeamleaderEmail { get; set; }

    public string? AutoComplete { get; set; }

    public string? LabelExtrastring1 { get; set; }

    public string? LabelExtrastring2 { get; set; }

    public string? ExcludeFromCreditcheck { get; set; }

    public string? CreateMove { get; set; }

    public string? Param1 { get; set; }

    public string? Param2 { get; set; }

    public string? Param1Label { get; set; }

    public string? Param2Label { get; set; }

    public string? LabelExtrastring1Label { get; set; }

    public string? LabelExtrastring2Label { get; set; }

    public string? LabelExtrastring3 { get; set; }

    public string? LabelExtrastring4 { get; set; }

    public string? LabelExtrastring5 { get; set; }

    public string? LabelExtrastring6 { get; set; }

    public string? GlobalLabel { get; set; }
}
