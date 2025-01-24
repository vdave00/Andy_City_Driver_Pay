using Andy_city_DriverFromTMWBIDW_API.DTO;

namespace Andy.Web.City_Driver_Pay.Models;

public class DayActivitiesDTO
{
    public DateOnly workDay { get; set; }
    public double? Totalhrs { get; set; }
    //public string Totalhrs { get; set; }

    public List<ordNumberDTO> OrdNumber { get; set; }
   // public object Driver_WorkedHours { get; set; }
}