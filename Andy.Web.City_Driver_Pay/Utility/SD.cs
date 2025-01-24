namespace Andy.Web.City_Driver_Pay.Utility
{
    public class SD
    {
        public static string DriverAPIBase { get; set; }

        public static string PayRateAPI {  get; set; }
        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }
    }
}
