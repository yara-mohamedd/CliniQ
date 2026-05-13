using Cliniq.DAL.Entities;
using Cliniq.DAL.Enum;
using Cliniq.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.DAL.Repo.Implementation
{
    public class PatientRepo : IPatientRepo

    {

        private Context Db = new Context();


        // add patient method
        public bool Add(Patient patient)
        {
          var res = Db.Patients.Add(patient);
            Db.SaveChanges();

            if(patient.Id >0 ) { return true; }
            else { return false; }
        }
        // get active patient 
        public List<Patient> GetActivePatients()
        {
            try
            {
                var result = Db.Patients
                    .Where(p => p.Appointments
                    .Any(a => a.Status == AppointmentStatus.Active))
                    .ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get all pateints 
        public List<Patient> GetAll()
        {
            var result = Db.Patients.ToList();
            return result;
        }

        public List<Patient> SearchByName(string name)
        {
            var result = Db.Patients
                .Where(p => p.Name.Contains(name))
                .ToList();

            return result;
        }

        // GetTodayPatients
        public List<Patient> GetTodayPatients()
        {
            try
            {
                var result = Db.Patients
                    .Where(p => p.CreatedAt.Date == DateTime.Today)
                    .ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        

       //update patient
        
        public bool Update(Patient Newpatient)
        {
            try
            {
                var oldpatient = Db.Patients.Where(p => p.Id == Newpatient.Id).FirstOrDefault();
                if (oldpatient != null)
                {
                    var resultt = oldpatient.Update(Newpatient.Name, Newpatient.complaint, Newpatient.address, Newpatient.Age);

                    if (resultt)
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

        //delete patient 
        public bool Delete(int id)
        {
            try
            {
                var oldpatient = Db.Patients
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

                if (oldpatient != null)
                {
                    Db.Patients.Remove(oldpatient);

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

      
    }

}
