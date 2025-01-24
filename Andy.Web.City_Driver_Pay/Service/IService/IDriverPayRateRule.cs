using Andy.Web.City_Driver_Pay.Models;

namespace Andy.Web.City_Driver_Pay.Service.IService
{
    public interface IDriverPayRateRule
    {
        Task<ResponseDTO> GetDriverName(string driverName);
        Task<ResponseDTO> GetDriverList(string Driverid);
        Task<ResponseDTO> GetAllDriverListAsync();
        Task<ResponseDTO> UpdatePayRateRule(string PayRate,decimal? Rate);
        Task<ResponseDTO> GetPayRule();
        Task<ResponseDTO> CreateDriverPayRate(AndyPayRateModelDTO driver);
        Task<ResponseDTO> UpdateDriverPayRate(int DriverPayRateID , AndyDriverPayRateDTO andyDriverPayRateDTO);
      
    }
}
