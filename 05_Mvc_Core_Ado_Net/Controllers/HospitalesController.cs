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
    }
}
