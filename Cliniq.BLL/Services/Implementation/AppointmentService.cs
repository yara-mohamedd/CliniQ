using Cliniq.BLL.Services.Abstraction;
using Cliniq.DAL.Entities;
using Cliniq.DAL.Enum;
using Cliniq.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cliniq.BLL.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public AppointmentService(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        // Add Appointment
        public bool AddAppointment(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                    return false;
                return _appointmentRepo.Add(appointment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Delete Appointment
        public bool DeleteAppointment(int id)
        {
            try
            {
                return _appointmentRepo.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get All
        public List<Appointment> GetAllAppointments()
        {
            try
            {
                return _appointmentRepo.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get By Id
        public Appointment GetAppointmentById(int id)
        {
            try
            {
                return _appointmentRepo.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update
        public bool UpdateAppointment(Appointment appointment)
        {
            try
            {
                return _appointmentRepo.Update(appointment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Today Appointments
        public List<Appointment> GetTodayAppointments()
        {
            try
            {
                return _appointmentRepo
                    .GetAll()
                    .Where(a => a.appointmentDate.Date == DateTime.Today)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Pending
        public List<Appointment> GetPendingAppointments()
        {
            try
            {
                return _appointmentRepo
                    .GetAll()
                    .Where(a => a.Status == AppointmentStatus.Pending)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Cancelled
        public List<Appointment> GetCancelledAppointments()
        {
            try
            {
                return _appointmentRepo
                    .GetAll()
                    .Where(a => a.Status == AppointmentStatus.Cancelled)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Completed
        public List<Appointment> GetCompletedAppointments()
        {
            try
            {
                return _appointmentRepo
                    .GetAll()
                    .Where(a => a.Status == AppointmentStatus.Completed)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Count Today
        public int GetTodayAppointmentsCount()
        {
            try
            {
                return _appointmentRepo
                    .GetAll()
                    .Count(a => a.appointmentDate.Date == DateTime.Today);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}