namespace Andy_city_DriverFromTMWBIDW_API.DTO
{
    public class ActivitiesListDTO
    {
        public string? TractorNo {  get; set; }
        public string ActivityName {  get; set; }
        public DateTime Activity_Time { get; set; }
        public decimal Activity_Minutes { get; set; }
        public decimal Kms { get; set;}
        public  int? OrderNo { get; set; }
        public string? MovNumber { get; set; }
        public string? Trailer {  get; set; }
        public string? Fleet { get; set; }
        public string ? Location { get; set; }
    }
}
