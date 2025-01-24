using Andy.Web.City_Driver_Pay.Models;
using Microsoft.AspNetCore.Mvc;

namespace Andy.Web.City_Driver_Pay.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                bool successful = loginViewModel.UserName!= null;
                HttpContext.Session.SetString("username", loginViewModel.UserName);
                if (successful)
                {
                    //HttpContext.Session.SetString("username", loginViewModel.UserName);
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }
     
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
