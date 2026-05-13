using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.DAL.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        public string address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string complaint { get; set; }



        // One Patient => Many Appointments
        public ICollection<Appointment> Appointments { get; set; }
            = new HashSet<Appointment>();


        public bool Update(string name, string complaint, string address, int age )
        {
            Name = name;
            this.complaint = complaint;
            this.address = address;
            Age = age;
            CreatedAt = DateTime.UtcNow;
            return true;
        }

    }
}
