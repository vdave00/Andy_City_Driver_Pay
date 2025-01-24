using Andy.Services.DriverApi.DTO;
using Andy.Services.DriverApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Andy.Services.DriverApi.Controllers
{
    [Route("api/CityDriverAPI")]
    [ApiController]
    public class Andy_City_Driver_Controller : ControllerBase
    {
        private ResponseDTO response;
        
        public Andy_City_Driver_Controller()
        {
            response = new ResponseDTO();
        }
        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                using (var _context = new TmwLiveContext())
                {
                    IEnumerable<AndyCityDriversList> objList = _context.AndyCityDriversLists.ToList();
                    response.Result = objList;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


        [HttpGet]
        [Route("{id}")]
        public ResponseDTO Get(string id)
        {
            try
            {
                using (var _context = new TmwLiveContext())
                {
                    AndyCityDriversList obj = _context.AndyCityDriversLists.First(u => u.MppId == id);
                    response.Result= obj;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}
