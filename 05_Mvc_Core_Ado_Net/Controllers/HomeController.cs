using _05_Mvc_Core_Ado_Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace _05_Mvc_Core_Ado_Net.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VistaMascota()
        {
            Mascota mascota = new Mascota();
            mascota.Nombre = "Daisy";
            mascota.Raza = "Yorksay Terrier";
            mascota.Edad = 7;
            return View(mascota);
        }
    }
}
