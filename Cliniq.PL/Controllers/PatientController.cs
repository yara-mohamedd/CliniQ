using Cliniq.BLL.Services.Abstraction;
using Cliniq.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cliniq.PL.Controllers
{
    public class PatientController : Controller
    {

        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // Get All Patients 

        public IActionResult Index(string searchName)
        {
            List<Patient> patients;

            if (!string.IsNullOrEmpty(searchName))
            {
                patients = _patientService
                    .GetPatientByName(searchName);
            }
            else
            {
                patients = _patientService
                    .GetAllPatients();
            }

            return View(patients);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var result = _patientService.AddPatient(patient);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(patient);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = _patientService
                .GetAllPatients()
                .FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var result = _patientService.UpdatePatient(patient);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(patient);
        }
        public IActionResult Delete(int id)
        {
            _patientService.DeletePatient(id);

            return RedirectToAction("Index");
        }



    }
}
