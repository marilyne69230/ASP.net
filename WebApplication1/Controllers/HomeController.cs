using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            string strMessage = "Bienvenue sur notre site frontal MVC";
            return View("Index", strMessage);
        }

        public IActionResult Inventaire()
        {
            List<string> liste = new List<string>();

            liste.Add("Marilyne");
            liste.Add("Margot");
            liste.Add("Lynda");
            liste.Add("Camelia");

            return View(liste);
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
}
