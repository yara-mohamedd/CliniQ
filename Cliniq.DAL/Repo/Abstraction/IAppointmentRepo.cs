using Cliniq.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.DAL.Repo.Abstraction
{
    public interface IAppointmentRepo
    {
        List<Appointment> GetAll();

        Appointment GetById(int id);

        bool Add(Appointment appointment);

        bool Update(Appointment appointment);

        bool Delete(int id);

    }
}
