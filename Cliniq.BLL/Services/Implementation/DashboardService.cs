using Cliniq.BLL.Services.Abstraction;
using Cliniq.DAL.Entities;
using Cliniq.DAL.Enum;
using Cliniq.DAL.Repo.Abstraction;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cliniq.BLL.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IAppointmentRepo _appointmentRepo;

        public DashboardService
        (
            IPatientRepo patientRepo,
            IAppointmentRepo appointmentRepo
        )
        {
            _patientRepo = patientRepo;
            _appointmentRepo = appointmentRepo;
        }

        // Total Patients
        public int TotalPatients()
        {
            try
            {
                return _patientRepo.GetAll().Count();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Active Patients
        public int ActivePatients()
        {
            try
            {
                return _patientRepo.GetActivePatients().Count();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Pending Patients
        public int PendingPatients()
        {
            try
            {
                return _appointmentRepo
                    .GetAll()
                    .Count(a => a.Status == AppointmentStatus.Pending);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Today Appointments
        public int TodayAppointments()
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

        // Today Schedule
        public List<Appointment> TodaySchedule()
        {
            try
            {
                return _appointmentRepo
                    .GetAll()
                    .Where(a => a.appointmentDate.Date == DateTime.Today)
                    .OrderBy(a => a.appointmentDate)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}