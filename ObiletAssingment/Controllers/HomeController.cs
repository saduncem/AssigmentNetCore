using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using ObiletAssingment.Models;
using ObiletAssingment.Service;
using ObiletAssingment.Services.Contract;

namespace ObiletAssingment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IObiletServices _obiletServices;
        public HomeController(IObiletServices obiletServices)
        {
            _obiletServices = obiletServices;

        }
        

        public async Task<IActionResult> Index()
        {
            var model = await _obiletServices.Getbuslocations(DateTime.Now);
                   
            return View(model);
        }


        [HttpPost]
        public async Task<JsonResult> Journeys(int OutDestination, int InDestination, DateTime transferdate)
        {

            var model = await _obiletServices.Getbusjourneys(DateTime.Now, transferdate, InDestination, OutDestination);
            var jsondata = JsonConvert.SerializeObject(model);
            return Json(jsondata);
        }


    }
}
