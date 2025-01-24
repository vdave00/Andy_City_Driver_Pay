using Andy.Web.City_Driver_Pay.Models;

namespace Andy.Web.City_Driver_Pay.Service.IService
{
    public interface IPayPeriodService
    {
        Task<ResponseDTO> GetPayPeriod();

        Task<ResponseDTO> GetDriverListAsync(string driverId);

    }
}
