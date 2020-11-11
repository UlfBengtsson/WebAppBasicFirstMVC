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
            List<Car> cars = _carService.All();
            return View(cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            _carService.Add(car.Brand, car.ModelName);

            return RedirectToAction(nameof(Index));
            //return RedirectToAction("Index");
        }
    }
}
