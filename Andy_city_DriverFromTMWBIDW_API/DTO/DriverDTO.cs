namespace Andy.Services.Andy_city_DriverFromTMWBIDW_API.DTO
{
    public class DriverDTO
    {
        public int Driverno { get; set; }

        public string? Driverid { get; set; }

        public string? DriverFname { get; set; }

        public string? DriverLname { get; set; }

        public DateTime? InsertDate { get; set; }

        public string? Eld { get; set; }

        public int? Drivertype { get; set; }

        public string? DriverFleet { get; set; }

		public int? OrderNumber { get; set; }
		public double? TotalHours { get; set; }
	}
}
