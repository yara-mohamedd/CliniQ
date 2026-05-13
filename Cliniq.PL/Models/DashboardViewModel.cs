using Cliniq.DAL.Entities;
using System.Collections.Generic;

namespace Cliniq.PL.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalPatients { get; set; }

        public int ActivePatients { get; set; }

        public int PendingAppointments { get; set; }

        public int TodayAppointments { get; set; }

        public List<Appointment> TodaySchedule { get; set; }
    }
}
