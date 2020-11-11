using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppFirstMVC.Models;

namespace WebAppFirstMVC.Controllers
{
    public class CarsController : Controller
    {
        CarService _carService = new CarService();
        public IActionResult Index()
        {
            ViewBag.CarList = _carService.All();
            return View();
        }
    }
}
