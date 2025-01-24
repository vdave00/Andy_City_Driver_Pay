using static Andy.Web.City_Driver_Pay.Utility.SD;
namespace Andy.Web.City_Driver_Pay.Models
 
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
