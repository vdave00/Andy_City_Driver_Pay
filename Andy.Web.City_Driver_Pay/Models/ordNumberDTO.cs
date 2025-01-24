using System.Security.Cryptography.X509Certificates;

namespace Andy_city_DriverFromTMWBIDW_API.DTO
{
	public class ordNumberDTO
	{
        public string DriverId { get; set; }
        public int? Ordnumber { get; set; }
        public double? TotalHoursForOrder { get; set; }
        public string? MovNumber { get; set; }
        public string? TruckNumber { get; set; }
        public string? TrailerNumber { get; set; }
        public string? Division { get; set; }
        public decimal? PayRate {  get; set; }
        public double? hours { get; set; }
        public string? Legnumber { get;  set; }
        public string? TMW_OrderNumber { get;  set; }
        public DateOnly? PayPeriod { get; set; }
        public decimal? PydAmount { get; set; }
        public decimal? CalculateHours { get; set; }
        public double? PaidHours { get; set; }
        public string? Notes { get; set; }
        public string? OTNotes { get; set; }


    }
}