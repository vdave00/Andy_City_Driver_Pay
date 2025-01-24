﻿using System.Data.SqlTypes;

namespace Andy.Web.City_Driver_Pay.Models
{
    public class PayEntryDTO
    {
     
        public int? Lgh_Number { get; set; }
        public int? Ord_Number { get; set; }
        public double? PayRate { get; set; }
        public double? PaydAmount { get; set; }
        public int? Mov_number { get; set; }
        public DateTime?PayPeriod { get; set; }
        public string Driverid { get; set; }
        public decimal? CalculateHours { get; set; }
        public double? PaidHours { get; set; }
        public string? OTNotes { get; set; }



       

    }
}
