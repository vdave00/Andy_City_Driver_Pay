namespace Andy_city_DriverFromTMWBIDW_API.DTO
{
    public class PayDetailsDTO
    {
        public string WeekStartDate { get; set; }
        public string WeekEndDate { get; set; }
        //public int TabId { get; set; }
       // public string DriverID { get; set; }
       // public string PayPeriod { get; set; }
        public List<PEntryDTO> PEntrylist { get; set; }
    }
}
