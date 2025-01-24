namespace Andy.Web.City_Driver_Pay.Models
{
    public class WeekActivitiesDTO
    {
            public DateOnly WeekStartDate { get; set; }
            public DateOnly WeekEndDate { get; set; }
            public double WeekHours { get; set; }
            public List<DayActivitiesDTO> DayActivities { get; set; }
    }
}
