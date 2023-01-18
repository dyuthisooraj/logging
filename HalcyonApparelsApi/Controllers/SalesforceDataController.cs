using HalcyonApparelsApplication.DTO;
using HalcyonApparelsApplication.Interfaces;
using HalcyonApparelsDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HalcyonApparelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesforceDataController : Controller
    {
        private readonly ISalesforceCrud _salesforceCrud;
        public SalesforceDataController(ISalesforceCrud salesforceCrud)
        {
            _salesforceCrud = salesforceCrud;
        }

        [HttpPost("Post")]
        //[Route]
        public async Task<IActionResult> SalesPost(List<CustomerDTO> cdto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Is not valid");

            else
            {
                _salesforceCrud.SalesforcePost(cdto);
                return Ok();
            }


        }
    }



    }

