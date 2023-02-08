using Microsoft.AspNetCore.Mvc;
using _05_Mvc_Core_Ado_Net.Repositories;
using _05_Mvc_Core_Ado_Net.Models;

namespace _05_Mvc_Core_Ado_Net.Controllers
{
    public class HospitalesController : Controller
    {

        private RepositoryHospital repo;

        public HospitalesController()
        {
            this.repo = new RepositoryHospital();
        }

        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Detalles(int idHospital)
        {
            Hospital hospital = this.repo.FindHospital(idHospital);

            return View(hospital);
        }

        public IActionResult CreateHospital()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHospital(Hospital hospital)
        {
            this.repo.CreateHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);

            ViewData["MENSAJE"] = "Hospital creado";

            //return View();
            return RedirectToAction("Index", "Hospitales");
        }
    }
}
