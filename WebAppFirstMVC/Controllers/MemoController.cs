using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppFirstMVC.Controllers
{
    public class MemoController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult SetMemo()
        {
            ViewBag.valueFromSession = HttpContext.Session.GetString("KeyName");
            
            return View("Memo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetMemo(string cliantMemo)
        {
            HttpContext.Session.SetString("KeyName", cliantMemo);

            return RedirectToAction(nameof(SetMemo));
        }
    }
}
