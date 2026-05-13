using Cliniq.BLL.Services.Abstraction;
using Cliniq.DAL.Entities;
using Cliniq.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.BLL.Services.Implementation
{
    public class PatientService :IPatientService
    {
        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }
        public bool AddPatient(Patient patient)
        {
            if (string.IsNullOrEmpty(patient.Name))
                return false;

            return _patientRepo.Add(patient);
        }

        public bool DeletePatient(int id)
        {
            return _patientRepo.Delete(id);
 
        }

        public List<Patient> GetActivePatients()
        {
            return _patientRepo.GetActivePatients();
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepo.GetAll();
        }

        public List<Patient> GetPatientByName(string name)
        {
            return _patientRepo.SearchByName(name);
        }

        public List<Patient> GetTodayPatients()
        {
            return _patientRepo.GetTodayPatients();
        }

        public bool UpdatePatient(Patient patient)
        {
            return _patientRepo.Update(patient);
        }
    }
}
