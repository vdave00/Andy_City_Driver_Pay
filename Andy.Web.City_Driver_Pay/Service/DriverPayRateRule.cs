using Andy.Web.City_Driver_Pay.Models;
using Andy.Web.City_Driver_Pay.Service.IService;
using Andy.Web.City_Driver_Pay.Utility;

namespace Andy.Web.City_Driver_Pay.Service
{
    public class DriverPayRateRule : IDriverPayRateRule
    {
        private readonly IBaseService _baseService;

        public DriverPayRateRule(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO> GetDriverList(string driverid)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url= "https://localhost:7108/api/DriverPayRate/" + driverid,

            });
        }
        public async Task<ResponseDTO> CreateDriverPayRate(AndyPayRateModelDTO driver)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Url = "https://localhost:7108/api/DriverPayRate",
                Data= driver
            });
        }

        public async Task<ResponseDTO> GetAllDriverListAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PayRateAPI+"/api/DriverPayRate" //"https://localhost:7108/api/DriverPayRate"   //https://localhost:7111/api/DriverWorkBook
																   //Url = SD.DriverAPIBase + "/api/CityDriverAPI"
			});
        }

        public async Task<ResponseDTO> GetDriverName(string driverName)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PayRateAPI+ "/api/DriverPayDetail/"+driverName  //"https://localhost:7108/api/DriverPayDetail/" + driverName
            });
        }

        public async Task<ResponseDTO> UpdateDriverPayRate(int DriverPayRateID, AndyDriverPayRateDTO andyDriverPayRateDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
               // Url = SD.PayRateAPI + "/api/DriverPayRate/"+DriverPayRateID   //https://localhost:7111/api/DriverWorkBook
                Url = "https://localhost:7108/api/DriverPayRate/"+DriverPayRateID,
                Data = andyDriverPayRateDTO
			});
        }

        public async Task<ResponseDTO> GetPayRule()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = "https://localhost:7108/api/DriverPayRate/GetPayRateRules"
            });
        }
        public Task<ResponseDTO> UpdatePayRateRule(string PayRate, decimal? formula)
        {
            string url = $"https://localhost:7108/api/DriverPayRate/PayType?payType={PayRate}&amount={formula?.ToString() ?? "0"}";
            return  _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Url = url,
            });
        }
    }
}
