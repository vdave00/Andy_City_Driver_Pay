namespace Andy.Web.City_Driver_Pay.Models
{
    public class AndyPayRateModelDTO
    {
        public string DivisionName { get; set; }
        public string DriverName { get; set; }
        public decimal RegularPayRate { get; set; } = 0.0m;
        public decimal OvertimePayRate { get; set; } = 0.0m;
        public decimal RegularPayRateEveningShift { get; set; } = 0.0m;
        public decimal OvertimePayRateEveningShift { get; set; } = 0.0m;
        public decimal RegularPayRateNightShift { get; set; } = 0.0m;
        public decimal OvertimePayRateNightShift { get; set; } = 0.0m;
        public decimal RatePerMile { get; set; } = 0.0m;
        public decimal? WeekendRate { get; set; }

        public DateOnly? EffectiveDateTo { get; set; }

        public DateOnly? EffectiveDateFrom { get; set; }

        public bool? IsActive { get; set; }

        public string? UpdateBy { get; set; }
    }
}
