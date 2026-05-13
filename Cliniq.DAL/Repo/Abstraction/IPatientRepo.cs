using Cliniq.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.DAL.Repo.Abstraction
{
    public interface IPatientRepo
    {
        bool Add (Patient patient);
         
        bool Update (Patient patient);

        bool Delete(int id);

        List<Patient> SearchByName(string name);


        List<Patient> GetAll ();

        List<Patient> GetActivePatients();

        List<Patient> GetTodayPatients();

     


    }
}
