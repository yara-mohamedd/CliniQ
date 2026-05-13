using Cliniq.BLL.Services.Abstraction;
using Cliniq.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cliniq.PL.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                TotalPatients = _dashboardService.TotalPatients(),

                ActivePatients = _dashboardService.ActivePatients(),

                PendingAppointments = _dashboardService.PendingPatients(),

                TodayAppointments = _dashboardService.TodayAppointments(),

                TodaySchedule = _dashboardService.TodaySchedule()
            };

            return View(model);
        }
    }
}