using System;
using System.Collections.Generic;

namespace Andy.Services.DriverApi.Models;

public partial class AndyCityDriversList
{
    public int Id { get; set; }

    public string? MppId { get; set; }

    public string? Startdate { get; set; }

    public string? Enddate { get; set; }
}
