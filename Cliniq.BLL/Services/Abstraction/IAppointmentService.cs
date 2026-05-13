using Cliniq.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Cliniq.BLL.Services.Abstraction
{
    public interface IAppointmentService
    {
        bool AddAppointment(Appointment appointment);

        bool UpdateAppointment(Appointment appointment);

        bool DeleteAppointment(int id);

        List<Appointment> GetAllAppointments();

        Appointment GetAppointmentById(int id);

        List<Appointment> GetTodayAppointments();

        List<Appointment> GetPendingAppointments();

        List<Appointment> GetCancelledAppointments();

        List<Appointment> GetCompletedAppointments();

        int GetTodayAppointmentsCount();
    }
}