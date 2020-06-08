using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MovieWeb.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Welcome(string name, int numberOfTimes = 1)
        {
            ViewData["Name"] = name;
            ViewData["NumberOfTimes"] = numberOfTimes;
            return View();
        }

        public IActionResult Today()
        {
            return View();
        }
    }
}
