using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICTWebApp.Models;
using ICTWebApp.Services.ThaiDate;

namespace ICTWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IThaiDate _thaiDate;

        public HomeController(ILogger<HomeController> logger,IThaiDate thaiDate)
        {
            _logger = logger;
            _thaiDate = thaiDate;
        }

        public IActionResult Index()
        {
            var myThaiDate = _thaiDate.ShowThaiDate();
            ViewBag.myThaiDate = myThaiDate;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
