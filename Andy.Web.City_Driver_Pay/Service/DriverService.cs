using Andy.Web.City_Driver_Pay.Models;
using Andy.Web.City_Driver_Pay.Service.IService;
using Andy.Web.City_Driver_Pay.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Andy.Web.City_Driver_Pay.Service
{
    public class DriverService : IDriverService
    {
        private readonly IBaseService _baseService;

        public DriverService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> AddedPayDetailInfo(PayDetailsList payDetails)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Url = "https://localhost:7111/api/DriverWorkBook",
                Data = payDetails
            });
        }

        public async Task<ResponseDTO> GetAllDriverListAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DriverAPIBase + "/api/DriverWorkBook"   //https://localhost:7111/api/DriverWorkBook
                //Url = SD.DriverAPIBase + "/api/CityDriverAPI"
            });
        }
        public async Task<ResponseDTO> GetAllDriverListAsync(DateTime sdate,DateTime edate,DateTime pyhPayPeriod)
        {
            string formattedSDate = sdate.ToString("yyyy-MM-dd");
            string formattedEDate = edate.ToString("yyyy-MM-dd");
            string fromattPayPeriod = pyhPayPeriod.ToString("yyyy-MM-dd");
            return await _baseService.SendAsync(new RequestDTO()
            {
              
            ApiType = SD.ApiType.GET,
               // Url = "https://localhost:7111/api/DriverWorkBook/api/drivers/2024-10-05/2024-10-12" //SD.DriverAPIBase + "api/DriverWorkBook/api/drivers/"+formattedSDate+"/"+formattedEDate
                Url = SD.DriverAPIBase + "/api/DriverWorkBook/api/drivers/"+formattedSDate+"/"+formattedEDate +"/"+ fromattPayPeriod// 2024-10-05/2024-10-12"
            });
        }
        public async Task<ResponseDTO> GetDriverListAsync(string driverId, DateTime sdate, DateTime edate, DateTime phyPayPeriod)
        {
            string formattedSdate = sdate.ToString("yyyy-MM-dd");
            string formattedEdate = edate.ToString("yyyy-MM-dd");
            string fromattPayPeriod = phyPayPeriod.ToString("yyyy-MM-dd");

            //DateOnly Sdate = DateOnly.FromDateTime(sdate);
            //DateOnly Edate = DateOnly.FromDateTime(edate);

            // string url = $"{SD.DriverAPIBase}/api/DriverWorkBook/{Uri.EscapeDataString(driverId)}/{Sdate}/{Edate}";
            //string url = $"{SD.DriverAPIBase}/api/DriverWorkBook/{Uri.EscapeDataString(driverId)}/{Sdate}/{Edate}";
            return await _baseService.SendAsync(new RequestDTO()
            {
                Url = SD.DriverAPIBase + "/api/DriverWorkBook/api/drivers/DriverRecordsHours/" + driverId + "/" + formattedSdate + "/" + formattedEdate +"/"+ fromattPayPeriod,
                //Url = SD.DriverAPIBase + "/api/DriverWorkBook/api/drivers/DriverRecords/" + driverId + "/" + formattedSdate + "/" + formattedEdate,
                ApiType = SD.ApiType.GET,
                //Url= url
                
                //Url = "https://localhost:7111/api/DriverWorkBook/ABOMO /2024-11-23/2024-11-30"
                //  Url = SD.DriverAPIBase + "/api/DriverWorkBook/" + driverId + "/"+sdate +"/"+edate   
            });
        }

        public async Task<ResponseDTO> GetFleet()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.DriverAPIBase + "/Fleet"
            });
        }

       
    }
}
