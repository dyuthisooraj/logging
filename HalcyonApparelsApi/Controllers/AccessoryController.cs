using HalcyonApparelsApplication.DTO;
using HalcyonApparelsApplication.Interfaces;
using HalcyonApparelsDomain.Entities;
using HalcyonApparelsInfrastructure.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace HalcyonApparelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {
        private readonly IAccessory _accsry;
        public AccessoryController(IAccessory accsry)
        {
            _accsry = accsry;
        }

        [HttpGet("Get")]

        public ActionResult<List<AccessoryDetails>> Get()
        {
            var result = _accsry.Get();
            return Ok(result);
        }

        [HttpPost("Post")]
        //[Route]
        public IActionResult Post(AccessoryDTO accdto)
        {
            AccessoryDetails accsry1 = new AccessoryDetails();
            if (!ModelState.IsValid)
                return BadRequest("Is not valid");

            else
            {
                {

                    accsry1.AccessoryId = accdto.AccessoryId;
                    accsry1.AccessoryName = accdto.AccessoryName;
                    accsry1.AccessoryType = accdto.AccessoryType;
                    accsry1.AccessoryBrand = accdto.AccessoryBrand;
                    accsry1.AccessoryPrice = accdto.AccessoryPrice;
                    accsry1.AccessoryDiscount = accdto.AccessoryDiscount;
                    accsry1.ImageUrl = accdto.ImageUrl;
                    

                }

            }

            _accsry.Post(accsry1);
            return Ok();
        }


        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            _accsry.Delete(id);
            return Ok();

        }

        [HttpGet]
        [Route("Get/{id}")]
        public ActionResult<AccessoryDetails> Get(int id)
        {
            return _accsry.Get(id);
        }

        
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(AccessoryDTO accdto)
        {
            AccessoryDetails acc4 = new AccessoryDetails();
            if (!ModelState.IsValid)
                return BadRequest("Is not valid");

            else
            {
                //{

                //    acc4.AccessoryId = accdto.AccessoryId;
                //    acc4.AccessoryName = accdto.AccessoryName;
                //    acc4.AccessoryType = accdto.AccessoryType;
                //    acc4.AccessoryBrand = accdto.AccessoryBrand;
                //    acc4.AccessoryPrice = accdto.AccessoryPrice;
                //    acc4.AccessoryDiscount = accdto.AccessoryDiscount;
                //    acc4.ImageUrl = accdto.ImageUrl;

                //}
                AccessoryDetails acc5 = _accsry.Get(accdto.AccessoryId);
                acc4.AccessoryId = accdto.AccessoryId;
                acc4.AccessoryName = accdto.AccessoryName;
                acc4.AccessoryType = accdto.AccessoryType;
                acc4.AccessoryBrand = accdto.AccessoryBrand;
                acc4.AccessoryPrice = accdto.AccessoryPrice;
                acc4.AccessoryDiscount = accdto.AccessoryDiscount;
                if (!string.IsNullOrWhiteSpace(accdto.ImageUrl))
                    acc4.ImageUrl = accdto.ImageUrl;
                else
                    acc4.ImageUrl = acc5.ImageUrl;

            }
            _accsry.Edit(acc4);

            return Ok();
        }
    }
}