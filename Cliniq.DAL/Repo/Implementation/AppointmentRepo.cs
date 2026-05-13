using Cliniq.DAL.Entities;
using Cliniq.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.DAL.Repo.Implementation
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private Context Db = new Context();

        //add Appoint
        public bool Add(Appointment appointment)
        {
            var res = Db.Appointments.Add(appointment);
            Db.SaveChanges();

            if (appointment.Id > 0) { return true; }
            else { return false; }
        }
        //delete app
        public bool Delete(int id)
        {
            try
            {
                var oldApp = Db.Appointments
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

                if (oldApp != null)
                {
                    Db.Appointments.Remove(oldApp);

                    Db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //getall
        public List<Appointment> GetAll()
        {
            var result = Db.Appointments
                .Include(a => a.Patient)
                .ToList();

            return result;
        }
        public Appointment GetById(int id)
        {
            try
            {
                var Appoint = Db.Appointments
                    .FirstOrDefault(p => p.Id == id);

                return Appoint;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Appointment appointment)
        {
            try
            {
                var newApp = Db.Appointments
                    .FirstOrDefault(p => p.Id == appointment.Id);

                if (newApp != null)
                {
                    var result = newApp.Update(
                        appointment.Id,
                        appointment.PatientId,
                        appointment.appointmentDate,
                        appointment.Status
                    );

                    if (result)
                    {
                        Db.SaveChanges();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
