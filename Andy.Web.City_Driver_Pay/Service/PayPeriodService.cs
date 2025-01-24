using Andy.Web.City_Driver_Pay.Models;
using Andy.Web.City_Driver_Pay.Service.IService;
using Andy.Web.City_Driver_Pay.Utility;

namespace Andy.Web.City_Driver_Pay.Service
{
    public class PayPeriodService : IPayPeriodService
    {
        private readonly IBaseService _baseService;

        public PayPeriodService (IBaseService baseService)
        {
            _baseService = baseService;
        }


     

        public Task<ResponseDTO> GetDriverListAsync(string driverId)
        {
            return  _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PayRateAPI +"api/DriverPayRate"+ "/" + driverId,

            });
        }

        public async Task<ResponseDTO> GetPayPeriod()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DriverAPIBase + "/api/PayPeriod"   //https://localhost:7111/api/DriverWorkBook
                //Url = SD.DriverAPIBase + "/api/CityDriverAPI"
            });
        }
    }
}
