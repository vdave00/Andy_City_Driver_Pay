using Andy.Web.City_Driver_Pay.Models;
using Microsoft.AspNetCore.Mvc;

namespace Andy.Web.City_Driver_Pay.Service.IService
{
    public interface IDriverService
    {
        Task<ResponseDTO> GetDriverListAsync(string driverId , DateTime startDate, DateTime endDate, DateTime pyhPayPeriod);
        Task<ResponseDTO> GetAllDriverListAsync();
        Task<ResponseDTO?> GetAllDriverListAsync(DateTime startDate, DateTime endDate, DateTime pyhPayPeriod);
        Task<ResponseDTO?> GetFleet();

        Task<ResponseDTO?>AddedPayDetailInfo([FromBody] PayDetailsList payDetails);


    }
}
