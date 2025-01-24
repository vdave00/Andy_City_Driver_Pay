using Andy.Web.City_Driver_Pay.Models;
using Andy.Web.City_Driver_Pay.Service;
using Andy.Web.City_Driver_Pay.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Andy.Web.City_Driver_Pay.Controllers
{
    public class DivisionController : Controller
    {
        private readonly IDriverPayRateRule _payRateRule;
        public DivisionController(IDriverPayRateRule payRateRule)
        {
            _payRateRule = payRateRule;
        }



        public async Task<IActionResult> GetAllRule()
        {
            List<AndyDriverPayRateDTO>? List = new();

            ResponseDTO? response = await _payRateRule.GetAllDriverListAsync();
            if (response != null)
            {
                List = JsonConvert.DeserializeObject<List<AndyDriverPayRateDTO>>(Convert.ToString(response.Result));
            }
            return View(List);

        }

        [HttpPut]
        [Route("Division/GetOneRule/{id}")]
        public async Task<IActionResult> GetOneRule(int id, [FromForm] AndyDriverPayRateDTO andyDriver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //AndyDriverPayRateDTO andyDriver1 = new AndyDriverPayRateDTO();
            var response = await _payRateRule.UpdateDriverPayRate(id, andyDriver);
            if (response?.Result != null)
            {
                return Json(new { success = true, redirectUrl = Url.Action("GetAllRule", "Division") });
            }

            return View("GetAllRule");
           // return Json(new { success = false, message = "Failed to update Pay Rate Rule." });
        }




        [HttpPut("UpdatID/{id}")]
        public async Task<IActionResult> UpdatID(int id, [FromBody] AndyDriverPayRateDTO dto)
        {
            if (id != dto.AndyDriverPayRateId)
            {
                return BadRequest("ID mismatch");
            }

            // Perform your update logic here
            // Example: Update the database with dto values

            return Ok(); // Respond with success
        }
        //DriverPayRateCreate
        [HttpPost]
        public async Task<IActionResult> DriverPayRateCreate(AndyPayRateModelDTO model) 
        {
            if (model != null) 
            {
                ResponseDTO? responseDTO = await _payRateRule.CreateDriverPayRate(model);
                if (responseDTO != null && responseDTO.IsSuccess)
                {
                    return RedirectToAction(nameof(GetAllRule));
                }
               
            }
            // need to put condition if Record is alredy in DB.. 
            return RedirectToAction(nameof(GetAllRule));
        }

        public async Task<IActionResult> DriverList(string driverid)
        {
            List<AndyDriverPayRateDTO> List = new();
            ResponseDTO response = await _payRateRule.GetDriverList(driverid);
            if (response != null)
            {
                List = JsonConvert.DeserializeObject<List<AndyDriverPayRateDTO>>(Convert.ToString(response.Result));
            }

            return View("GetAllRule", List); // Return the same view with the updated data
        }
        //[HttpPut]



    }
}

