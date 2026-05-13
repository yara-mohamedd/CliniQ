using Cliniq.DAL.Entities;
using System.Collections.Generic;

namespace Cliniq.BLL.Services.Abstraction
{
    public interface IDashboardService
    {
        int TotalPatients();

        int ActivePatients();

        int PendingPatients();

        int TodayAppointments();

        List<Appointment> TodaySchedule();
    }
}