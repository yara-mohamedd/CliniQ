using Azure;
using Cliniq.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.DAL.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId{ get; set; }
        public DateTime appointmentDate { get; set; } = DateTime.Now.AddHours(1);

        public AppointmentStatus Status { get; set; }


        // Navigation Property
        public Patient Patient { get; set; }

        public bool Update(int id, int patientId, DateTime appDate, AppointmentStatus stat)
        {
            Id = id;
            PatientId = patientId;
            appointmentDate = appDate;
            Status = stat;
            return true;
        }

    }
}
