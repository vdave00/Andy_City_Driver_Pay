using Andy.Web.City_Driver_Pay.Models;
using Andy.Web.City_Driver_Pay.Service;
using Andy.Web.City_Driver_Pay.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Andy.Web.City_Driver_Pay.Controllers
{
	public class PayperiodController : Controller
	{
        private readonly IPayPeriodService _payPeriodService;
        public PayperiodController(IPayPeriodService payPeriodService)
        {
            _payPeriodService = payPeriodService;
        }

        public async Task<IActionResult> PayPeriodsAsync()
		{
            List<PayPeriodDTO>? List = new();
            ResponseDTO? response = await _payPeriodService.GetPayPeriod();
            if (response != null)
            {
                List = JsonConvert.DeserializeObject<List<PayPeriodDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
            //return View(payPeriods);
		}

        public async Task<IActionResult> GetDriverList(string driverid)
        {
            List<PayPeriodDTO>? List = new();
            ResponseDTO response = await _payPeriodService.GetDriverListAsync(driverid);
            if (response != null)
            {
                List = JsonConvert.DeserializeObject<List<PayPeriodDTO>>(Convert.ToString((ResponseDTO)response.Result));
            }
            return View(List);
        }

    }
}
