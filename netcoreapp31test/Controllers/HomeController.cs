using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netcoreapp31test.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace netcoreapp31test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("EnvironmentVariables")]
        public IEnumerable<EnvironmentVariable> GetEnvironmentVariables()
        {
            return EnvironmentVariable.GetEnvironmentVariables();
        }

        [HttpGet("LoadedDLLs")]

        public IEnumerable<LoadedDLL> GetLoadedDLLs()
        {
            return LoadedDLL.GetLoadedDLLs();
        }
    }
}
