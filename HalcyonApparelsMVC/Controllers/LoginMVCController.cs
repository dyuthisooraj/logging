using Microsoft.AspNetCore.Mvc;
using HalcyonApparelsMVC.Models;
using HalcyonApparelsMVC.Interfaces;

namespace HalcyonApparelsMVC.Controllers
{
    public class LoginMVCController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ISalesforceData _salesforcedata;

        public LoginMVCController(IConfiguration config, ISalesforceData salesforcedata)
        {
            _config = config;
            _salesforcedata = salesforcedata;
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginMVC loginDetails)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_config["WebConfig:UserApi"]);
            var postTask = client.PostAsJsonAsync("api/Login", loginDetails);
            postTask.Wait();
            var Result = postTask.Result;
            if (!Result.IsSuccessStatusCode)
            {
                ViewData["LoginFlag"] = "Invalid Login";
                return View();
            }
            CustomerAdd();
            return RedirectToAction("Mail", "Marketing");
            //return RedirectToAction("AccessoryView", "Home");
        }


        public bool CustomerAdd()
        {
            var access_token = HttpContext.Session.GetString("Acces_token").ToString();

            var response = _salesforcedata.SalesforceCustomerDetails(access_token);
            var isTrue = _salesforcedata.Post(response);
            
            //return response;
            return true;
        }
         
    }


}
