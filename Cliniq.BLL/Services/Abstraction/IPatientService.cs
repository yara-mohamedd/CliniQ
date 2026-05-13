using Cliniq.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.BLL.Services.Abstraction
{
    public interface IPatientService
    {
        bool AddPatient(Patient patient);

        bool UpdatePatient(Patient patient);

        bool DeletePatient(int id);

        List<Patient> GetAllPatients();

       List< Patient> GetPatientByName(string name);

        List<Patient> GetActivePatients();

        List<Patient> GetTodayPatients();
    }
}
