using Cliniq.BLL.Services.Abstraction;
using Cliniq.BLL.Services.Implementation;
using Cliniq.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cliniq.PL.Controllers
{
    public class AppointmentController :Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return View(appointments);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Appointment appointment)
      {
            ModelState.Remove("Patient");
            if (ModelState.IsValid)
            {
                var result = _appointmentService.AddAppointment(appointment);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(appointment);
        }

        public IActionResult Delete(int id)
        {
            _appointmentService.DeleteAppointment(id);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var appointment =_appointmentService.GetAllAppointments()
                .FirstOrDefault(p => p.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            ModelState.Remove("Patient");
            if (ModelState.IsValid)
            {
                var result = _appointmentService.UpdateAppointment(appointment);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(appointment);
        }
    }
}
