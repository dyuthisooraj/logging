using HalcyonApparelsMVC.DTO;
using HalcyonApparelsMVC.Interfaces;
using HalcyonApparelsMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceStack;
using System.Diagnostics;
using System.Net.Http.Json;

namespace HalcyonApparelsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ISalesforceData _salesforcedata;
        private readonly IConfiguration _config;


        public HomeController(IWebHostEnvironment environment, ISalesforceData salesforcedata, IConfiguration config)
        {
            _environment = environment;
            _salesforcedata = salesforcedata;
            _config = config;

        }

        public async Task<IActionResult> AccessoryView()
        {
            
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };

            HttpClient client = new HttpClient(clienthandler);
            client.BaseAddress = new Uri(_config["WebConfig:UserApi"]);
            List<AccessoryDetailsMVC>? acclist = new List<AccessoryDetailsMVC>();

            HttpResponseMessage res = client.GetAsync("api/Accessory/Get").Result;
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                acclist = JsonConvert.DeserializeObject<List<AccessoryDetailsMVC>>(result);
            }
            return View(acclist);

        }

        [HttpGet]
        public ActionResult _PostPartial()
        {
            return PartialView();
        }


        [HttpGet]
        public async Task<IActionResult> _EditPartial(int id)
        {
            TempData["id"] = id;
            var client = new HttpClient();
            client.BaseAddress = new Uri(_config["WebConfig:UserApi"]);

            TempData accssry = new TempData();
            HttpResponseMessage res = await client.GetAsync($"api/Accessory/Get/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                accssry = JsonConvert.DeserializeObject<TempData>(result);
            }


            return PartialView(accssry);
        }

        [HttpGet]
        public async Task<IActionResult> _DetailsPartial(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_config["WebConfig:UserApi"]);
            AccessoryDetailsMVC accss = new AccessoryDetailsMVC();

            HttpResponseMessage res = await client.GetAsync($"api/Accessory/Get/{id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                accss = JsonConvert.DeserializeObject<AccessoryDetailsMVC>(result);
            }

            return PartialView(accss);

        }


        //[HttpPost]
        public IActionResult Post(AccessoryDetailsMVC accsrydet)
        {
            accsrydet.ImageUrl = "file";
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };
            string uniqueFileName = ProcessUploadedFile(accsrydet);

            AccessoryDTO adto = new AccessoryDTO();
            {
                adto.AccessoryId = accsrydet.AccessoryId;
                adto.AccessoryName = accsrydet.AccessoryName;
                adto.AccessoryType = accsrydet.AccessoryType;
                adto.AccessoryBrand = accsrydet.AccessoryBrand;
                adto.AccessoryPrice = accsrydet.AccessoryPrice;
                adto.AccessoryDiscount = accsrydet.AccessoryDiscount;
                adto.ImageUrl = uniqueFileName;
                //adto.ProductType = accsrydet.ProductType;

            }



            HttpClient client = new HttpClient(clienthandler);
            client.BaseAddress = new Uri(_config["WebConfig:UserApi"]);
            var postTask = client.PostAsJsonAsync<AccessoryDTO>("api/Accessory/Post/", adto);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                TempData["AlertMessage"] = " Accessory Added ";
                return RedirectToAction("AccessoryView");
            }

            return View();

        }



        public async Task<IActionResult> Delete(int id)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(_config["WebConfig:UserApi"]);
            await client.DeleteAsync($"api/Accessory/Delete/{id}");

            TempData["AlertMessage"] = " Accessory Deleted ";
            return RedirectToAction("AccessoryView");


        }

        [HttpPost]
        public async Task<IActionResult> Edit(TempData temp)
        {
            
           temp.ImageUrl = "file";
           temp.AccessoryId = Convert.ToInt32(TempData["id"]);
           var client = new HttpClient();
           string uniqueFileName = ProcessUploadFileEdit(temp);

            AccessoryDTO adto = new AccessoryDTO();
            {
                
                    adto.AccessoryId = temp.AccessoryId;
                    adto.AccessoryName = temp.AccessoryName;
                    adto.AccessoryType = temp.AccessoryType;
                    adto.AccessoryBrand = temp.AccessoryBrand;
                    adto.AccessoryPrice = temp.AccessoryPrice;
                    adto.AccessoryDiscount = temp.AccessoryDiscount;
                adto.ImageUrl = uniqueFileName;

            }
                

            client.BaseAddress = new Uri(_config["WebConfig:UserApi"]);
            
                var postTask = client.PostAsJsonAsync<AccessoryDTO>("api/Accessory/Edit", adto);
                postTask.Wait();
                var Result = postTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    TempData["AlertMessage"] = " Accessory Updated";
                    return RedirectToAction("AccessoryView");
                }
                return PartialView();
    
        }

        private string ProcessUploadedFile(AccessoryDetailsMVC model)
        {
            string uniqueFileName = null;

            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "photos");
                
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }


        private string ProcessUploadFileEdit(TempData tempmodel)
        {
            string uniqueEditedFileName = String.Empty;

            if (tempmodel.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "photos");

                uniqueEditedFileName = Guid.NewGuid().ToString() + "_" + tempmodel.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueEditedFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    tempmodel.ImageFile.CopyTo(fileStream);
                }
            }

            return uniqueEditedFileName;
        }




        public ActionResult Marketing()
        {
            
            return RedirectToAction("MarketingView", "Marketing");
        }

        public ActionResult Logout()
        {

            HttpContext.Session.Clear();
            

            return RedirectToAction("Login", "LoginMVC");
        }



    }


}


