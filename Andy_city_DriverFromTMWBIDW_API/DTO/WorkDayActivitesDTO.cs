namespace Andy_city_DriverFromTMWBIDW_API.DTO
{
    public class WorkDayActivitesDTO
    {
        public string? DriverID {  get; set; }
        public string DriverName { get; set;}
        public string Fleet {  get; set;}
        public string Division { get;set;}
        public DateOnly ActivityDate { get; set; }
        public string OrderNo { get; set; }
        public double? TotalHrs { get; set; }
        
        public string? DriverPayRate { get; set; }

        public List<ActivitiesListDTO> ActivityLists { get; set; }


        
    }
}
