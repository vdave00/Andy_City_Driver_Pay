namespace Andy_city_DriverFromTMWBIDW_API.DTO
{
    public class PayPeriodDTO
    {
        public DateOnly PayperiodStartDate { get; set; }
        public DateOnly PayperiodEndDate { get; set;}
        public DateOnly PayDayDate { get; set; }
        public int CountOFDriver { get; set; }
        public int NoOfOrders { get; set; }
        public float TotalHoursWorked { get; set; }



    }
}
