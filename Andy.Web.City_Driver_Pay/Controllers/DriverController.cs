using Andy.Web.City_Driver_Pay.Models;
using Andy.Web.City_Driver_Pay.Models.SecondDb;
using Andy.Web.City_Driver_Pay.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Andy.Web.City_Driver_Pay.Controllers
{
	public class DriverController : Controller
	{
		private readonly IDriverService _driverService;
        //private readonly DbContext dbContext;

		public DriverController(IDriverService driverService)
		{
			_driverService = driverService;
		}

		public async Task<IActionResult> DriverIndex()
		{

			List<DriverDTO>? List = new();

			ResponseDTO? response = await _driverService.GetAllDriverListAsync();
			if (response != null)
			{
				List = JsonConvert.DeserializeObject<List<DriverDTO>>(Convert.ToString(response.Result));
			}
			return View(List);
		}
        public async Task<IActionResult> DriversBook(DateTime startDate, DateTime endDate, DateTime pyhPayPeriod)
        {
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.PayPeriod = pyhPayPeriod;
            List<DriverDTO>? driverList = new();
           
            ResponseDTO? response = await _driverService.GetAllDriverListAsync(startDate, endDate, pyhPayPeriod);
            if (response != null)
            {
                driverList = JsonConvert.DeserializeObject<List<DriverDTO>>(Convert.ToString(response.Result));
            }

            // Extract distinct fleets and pass them to the view using ViewBag
            var distinctFleets = driverList
                .Where(d => !string.IsNullOrEmpty(d.DriverFleet)) // Ensure valid fleets
                .Select(d => d.DriverFleet.Trim()) // Remove extra spaces
                .Distinct()
                .OrderBy(f => f) // Optional: Alphabetical order
                .ToList();

            ViewBag.Fleets = distinctFleets; // Pass the fleet list to the view
            return View(driverList);
        }


        public async Task<IActionResult> DriverBook(string fleet, DateTime sdate, DateTime edate,DateTime payPeriod)
        {
            // Fetch driver list based on fleet filter
            ViewBag.StartDate = sdate;
            ViewBag.EndDate = edate;
            ViewBag.PayPeriod = payPeriod;  
            List<DriverDTO>? driverList = new();

            ResponseDTO? response = await _driverService.GetAllDriverListAsync(sdate, edate, payPeriod);
            if (response != null)
            {
                driverList = JsonConvert.DeserializeObject<List<DriverDTO>>(Convert.ToString(response.Result));
            }

            // Fetch fleet list from a service or database
            var distinctFleets = driverList
                .Where(d => !string.IsNullOrEmpty(d.DriverFleet)) // Ensure valid fleets
                .Select(d => d.DriverFleet.Trim()) // Remove extra spaces
                .Distinct()
                .OrderBy(f => f) // Optional: Alphabetical order
                .ToList();

            // Pass the data to the view
            ViewBag.Fleets = distinctFleets;
            ViewBag.SelectedFleet = fleet;
            //ViewBag.StartDate = sdate;
            //ViewBag.EndDate = edate;
            //ViewData["StartDate"] = sdate;
            //ViewData["EndDate"] = edate;

            return View("DriversBook",driverList);
        }


        public async Task<IActionResult> DriverView(string driverid, DateTime sdate, DateTime edate,DateTime pdate)
		{
            ViewBag.PayPeriod = pdate;
            List<WeekActivitiesDTO>? List = new();

			ResponseDTO? response = await _driverService.GetDriverListAsync(driverid,sdate,edate, pdate);
			if (response != null)
			{
				List = JsonConvert.DeserializeObject<List<WeekActivitiesDTO>>(Convert.ToString(response.Result));
			}
			return View(List);

		}



        [HttpPost]
       // [Route("Driver/AddPayDetails")]
        public async Task<IActionResult> AddPayDetails([FromBody] PayDetailsList payDetailsList)
        {
            string driverId = ""; // Replace with the correct property from your DTO
            DateTime sDate = Convert.ToDateTime(payDetailsList.WeekStartDate); // Replace with the correct property
            DateTime eDate = Convert.ToDateTime(payDetailsList.WeekEndDate);   // Replace with the correct property
            DateTime pDate = eDate;

            foreach(var  item in payDetailsList.PEntrylist)
            {
                pDate =Convert.ToDateTime(item.PayPeriod);
                driverId=item.Driverid;
                break;
            }
            //= Convert.ToDateTime(payDetailsList.PayPeriod.Trim());

            var response = await _driverService.AddedPayDetailInfo(payDetailsList);
            if (response?.Result != null)
            {
                return RedirectToAction(nameof(DriverView), new { driverid = driverId, sdate = sDate, edate = eDate, pdate = pDate });
            }
            else
            {

                // Redirect to DriverView with parameters
                return RedirectToAction(nameof(DriverView), new { driverid = driverId, sdate = sDate, edate = eDate, pdate = pDate });
            }
            //return View();
        }
            



    }
}
