using Andy_Driver_PayRate_Rule_API.DTO;
using Andy_Driver_PayRate_Rule_API.Models;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Andy_Driver_PayRate_Rule_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverPayDetailController : ControllerBase
    {
        private readonly TmwLiveContext _context;
        private ResponseDTO response;

        public DriverPayDetailController(TmwLiveContext context)
        {
            _context = context;
            response = new ResponseDTO();
        }



        // Get All Driver's info..
        [HttpGet]
        public ResponseDTO GetPayRateDetaiol()
        {
            try
            {
                using (var _context = new TmwLiveContext())
                {
                    IEnumerable<AndyDriverPayRate> objList = _context.AndyDriverPayRates.ToList();
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

        //Get Specific Driver Details...
        [HttpGet("{driverName}")]
        public async Task<ActionResult<IEnumerable<string>>> GetDriverNames(string? driverName)
        {
            if (!string.IsNullOrEmpty(driverName) && driverName.Length >= 2)
            {
                // Return only driver names that start with the given letters
                return await _context.AndyDriverPayDetails
                    .Where(d => d.DriverId.StartsWith(driverName))
                    .Select(d => d.DriverId )
                    .Distinct() // Optional: Remove duplicates
                    .ToListAsync();
            }

            // Return an empty list if no valid filter is provided
            return new List<string>();
        }
    }
}
