using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using peak.DDD.Site.Models;

namespace peak.DDD.Site.Controllers
{
    public class HomeController : Controller
    {
        [EnableCors("MyPolicy")]
        public IActionResult Index()
        {
            return View();
        }
        [EnableCors("MyPolicy")]
        public IActionResult CalcPerc()
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
