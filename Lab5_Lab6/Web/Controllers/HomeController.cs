using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
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
            var urlRequest = "https://localhost:7115/api/Home";
            var response = new HttpClient().GetStringAsync(urlRequest).Result;
            List<Compounding> compounding = JsonConvert.DeserializeObject<List<Compounding>>(response);
            return View(compounding);
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
    }

    public class Compounding
    {
        public int sothang { get; set; }
        public long sotien { get; set; }
        public double tylelai { get; set; }
        public double lai { get; set; }
    }
}