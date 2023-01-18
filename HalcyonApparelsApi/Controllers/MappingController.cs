using HalcyonApparelsApplication.DTO;
using HalcyonApparelsApplication.Interfaces;
using HalcyonApparelsDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HalcyonApparelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingController : Controller
    {

        private readonly IMapping _mapping;
        public MappingController(IMapping mapping)
        {
            _mapping=mapping;
        }


        [HttpGet("GetCustomer")]
        //[Route("get1/{param1}")]
        public ActionResult<List<CustomerDetails>> GetCustomer()
        {
            var result = _mapping.GetCustomer();
            return Ok(result);
        }


        [HttpGet("GetAccessoryType")]
        //[Route("get2/{param1}")]
        public ActionResult<List<AccessoryDetails>> GetAccessoryType()
        {
            var result = _mapping.GetAccessoryType();
            return Ok(result);
        }


        [HttpGet("GetProductType")]
        //[Route("get2/{param1}")]
        public ActionResult<List<ProductType>> GetProductType()
        {
            var result = _mapping.GetProductType();
            return Ok(result);
        }


        [HttpPost("PostMarketing")]
        //[Route("get2/{param1}")]
        public ActionResult PostMarketing([FromBody] MapDTO map)
        {
            var result = _mapping.Addaccsry(map.accessorytype, map.productType);
            return Ok(result);
        }

    }
}
