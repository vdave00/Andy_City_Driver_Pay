namespace Andy_Driver_PayRate_Rule_API.DTO
{
    public class AndyDriverPayRateDTO
    {
        public string? DriverFname { get; set; }
        public string? DriverLName { get; set; }
        public string? DriverId { get; set; }

        public string? FleetCompanyId { get; set; }

        public decimal? RegularRateDayShift { get; set; }

        public decimal? RegularRateEveShift { get; set; }

        public decimal? RegularRateNightShift { get; set; }

        public decimal? OverTimeRateDayShift { get; set; }

        public decimal? OverTimeRateEveShift { get; set; }

        public decimal? OverTimeRateNightShift { get; set; }

        public int? AndyDriverPayRateId { get; set; }
        public decimal? RatePerMileage { get; set; }
        public decimal? WeekendRate { get; set; }
        public decimal? OverTimeRateWeekendShift { get; set; }

        public DateOnly? EffectiveDateTo { get; set; }

        public DateOnly? EffectiveDateFrom { get; set; }

        public bool? IsActive { get; set; }

        public string? UpdateBy { get; set; }
    }
}