namespace Andy_city_DriverFromTMWBIDW_API.DTO
{
    public class DayActivitiesDTO
    {
        public DateOnly workDay { get; set; }
        public double? Totalhrs { get; set; }
        //public double? WeekHours { get; set; }

        public List<ordNumberDTO>? OrdNumber { get; set; }

       
    }
}