namespace Andy.Web.City_Driver_Pay.Models
{
    public class PayDetailsList
    {
        public  string WeekStartDate { get; set; }
        public string WeekEndDate { get; set; }
        //public int TabId { get; set; }
       // public string DriverID { get; set; }
        //public string PayPeriod { get; set; }
        public List<PayEntryDTO> PEntrylist { get; set; }
    }
}
