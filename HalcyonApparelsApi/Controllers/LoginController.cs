using HalcyonApparelsDomain.Entities;
using HalcyonApparelsInfrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HalcyonApparelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly AppDBContext db;

        private readonly IConfiguration _config;
        public LoginController(AppDBContext dContext, IConfiguration configuration)
        {
            db = dContext;
            _config = configuration;
        }



        [HttpPost]

        public IActionResult Login(AdminLogin adminlogin)
        {
            if (ModelState.IsValid)
            {
                var credentials = db.LoginCredentials.Where(model => model.UserName == adminlogin.UserName && model.Password == adminlogin.Password).FirstOrDefault();
                if (credentials == null)
                {
                    
                   
                    
                    return BadRequest("Login Failed");
                }
                else
                {

                    return Ok("Login Success");

                }

            }
            else
            {
                return BadRequest();
            }

        }
    }

}
