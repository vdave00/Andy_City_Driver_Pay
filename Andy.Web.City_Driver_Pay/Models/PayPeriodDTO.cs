namespace Andy.Web.City_Driver_Pay.Models
{
    public class PayPeriodDTO
    {
        public DateOnly PayperiodStartDate { get; set; }
        public DateOnly PayperiodEndDate { get; set;}
        public DateOnly payDayDate {  get; set; }
        public int CountOFDriver { get; set; }
        public int NoOfOrders { get; set; }
        public float TotalHoursWorked { get; set; }



    }
}
