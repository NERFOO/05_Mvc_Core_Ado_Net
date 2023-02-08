using _05_Mvc_Core_Ado_Net.Models;
using _05_Mvc_Core_Ado_Net.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _05_Mvc_Core_Ado_Net.Controllers
{
    public class DoctoresController : Controller
    {

        RepositoryDoctor repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctor();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();

            List<string> especialidades = this.repo.GetEspecialidades();

            //DatosDoctores modelDatos = new DatosDoctores();
            //modelDatos.Especialidades = especialidades;
            //modelDatos.Doctores = doctores;

            ViewData["ESPECIALIDADES"] = especialidades;

            return View(doctores);
        }
            
        [HttpPost]
        public IActionResult Index(string especialidad)
        {
            List<Doctor> doctores = this.repo.GetDoctores(especialidad);

            List<string> especialidades = this.repo.GetEspecialidades();

            //DatosDoctores model = new DatosDoctores();
            //model.Doctores = doctores;
            //model.Especialidades = especialidades;

            ViewData["ESPECIALIDADES"] = especialidades;

            return View(doctores);
        }

        public IActionResult DoctoresHospital()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            ViewData["HOSPITALES"] = hospitales;

            return View();
        }
        [HttpPost]
        public IActionResult DoctoresHospital(string idHospital)
        {
            List<Doctor> doctores = this.repo.GetDoctoresHospital(idHospital);

            List<Hospital> hospitales = this.repo.GetHospitales();
            ViewData["HOSPITALES"] = hospitales;

            return View(doctores);
        }
    }
}
