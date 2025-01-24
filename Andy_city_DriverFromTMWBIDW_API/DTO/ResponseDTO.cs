using Andy_city_DriverFromTMWBIDW_API.DTO;

namespace Andy.Services.Andy_city_DriverFromTMWBIDW_API.DTO;

public class ResponseDTO
{
    public Object? Result {  get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "";

    public static implicit operator ResponseDTO(List<WorkDayActivitesDTO> v)
    {
        throw new NotImplementedException();
    }

    public static implicit operator ResponseDTO(List<string?> v)
    {
        throw new NotImplementedException();
    }
}
