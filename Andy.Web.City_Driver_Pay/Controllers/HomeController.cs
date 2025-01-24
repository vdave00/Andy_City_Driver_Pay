using Andy.Web.City_Driver_Pay.Models;
using Andy.Web.City_Driver_Pay.Service;
using Andy.Web.City_Driver_Pay.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Andy.Web.City_Driver_Pay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDriverPayRateRule _driverService;

        public HomeController(ILogger<HomeController> logger, IDriverPayRateRule payRateRule)
        {
            _logger = logger;
            _driverService = payRateRule;
        }
      

        //[HttpPost]
        //public Task<IActionResult> Login(LoginViewModel loginDTO)
        //{
          
        //    bool isAuthenticated = true;
        //    if (isAuthenticated)
        //    {
        //        HttpContext.Session.SetString("User", loginDTO.UserName);
        //        //return View();
        //    }
        //    //return View();
        //    //return View(loginDTO);
        //}

        public async Task<IActionResult> GetRule()
        {
            List<AndyPayRateRuleDTO> List = new();

            ResponseDTO? response = await _driverService.GetPayRule();
            if (response != null)
            {
                List = JsonConvert.DeserializeObject<List<AndyPayRateRuleDTO>>(Convert.ToString(response.Result));
            }
            //return View(List);

            return View("Index", List);
        }


        public  async Task <IActionResult> Index()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                List<AndyPayRateRuleDTO> List = new();

                ResponseDTO? response = await _driverService.GetPayRule();
                if (response != null)
                {
                    List = JsonConvert.DeserializeObject<List<AndyPayRateRuleDTO>>(Convert.ToString(response.Result));
                }

                return View(List);
            }
        }


        public async Task <IActionResult> UpdatePayRate(string PayRateName,decimal formula)
        {
            List <AndyPayRateRuleDTO> List = new();

            ResponseDTO? response1 = await _driverService.UpdatePayRateRule(PayRateName, formula);
            if (response1 != null)
            {
                ResponseDTO? response = await _driverService.GetPayRule();
                List = JsonConvert.DeserializeObject<List<AndyPayRateRuleDTO>>(Convert.ToString(response.Result));
            }
            return View("Index",List);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> DivisionCreate()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
