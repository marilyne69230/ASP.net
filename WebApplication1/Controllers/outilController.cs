using FrontalMVC.Models.Perso;
using Microsoft.AspNetCore.Mvc;

namespace FrontalMVC.Controllers
{
    public class outilController : Controller
    {
        private IGenerateur _generateur;
        public outilController(IGenerateur generateur) 
        {
            _generateur = generateur;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Generation()
        {
            var serie = _generateur.Generer(10);
            return View(serie);
        }

        public IActionResult ResteJours()
        {
            DateTime jour = DateTime.Today;
            DateTime finCoursus = new DateTime(2024, 3, 15);

            int result = finCoursus.Subtract(jour).Days;

            return View(result);
        }
    }
}
