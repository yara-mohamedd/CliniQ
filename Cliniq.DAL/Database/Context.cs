using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cliniq.DAL.Entities
{
    internal class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-BEFS9U4;Database=CliniqqDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)              // Appointment has one Patient
                .WithMany(p => p.Appointments)      // Patient has many Appointments
                .HasForeignKey(a => a.PatientId);   // FK
        }
    }

}

