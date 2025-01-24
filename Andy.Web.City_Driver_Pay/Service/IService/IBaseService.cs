using Andy.Web.City_Driver_Pay.Models;

namespace Andy.Web.City_Driver_Pay.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
    }
}
