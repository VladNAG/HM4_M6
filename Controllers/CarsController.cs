using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HM4_M6.Controllers;
using HM4_M6.Interface;
using HM4_M6.Models;

namespace HM4_M6.Controllers
{
    public class CaarsController : Controller
    {
        private ICarSevises _iCarSevises;
        public CaarsController(ICarSevises CarSevises)
        {
            _iCarSevises = CarSevises;
        }
        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            List<CarViewModel> model = _iCarSevises.GetAll();
            return View(model);
        }

        [HttpPost]
        [Route("Caars/Test")]
        public IActionResult GreateTest(int id, string car, int price, string odel)
        {

            CarViewModel ca = new CarViewModel { Id = id, Name = car, Price = price, Model= odel };
            _iCarSevises.Create(ca);
            List<CarViewModel> model = _iCarSevises.GetAll();
            return View("~/Views/Caars/Test.cshtml", model);
        }

        [HttpPost]
        [Route("DeleteTest")]
        public IActionResult DeleteTest(int id)
        {
            _iCarSevises.Delete(id);
            return RedirectToAction("Test");
        }

        [HttpGet]
        [Route("Info")]
        public IActionResult Info(int id)
        {
            CarViewModel model = _iCarSevises.Get(id);
            return View(model);
        }
    }
}
