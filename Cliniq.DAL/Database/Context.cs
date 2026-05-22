using Cliniq.DAL.identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cliniq.DAL.Entities
{
    public class Context : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring
        (
            DbContextOptionsBuilder optionsBuilder
        )
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-BEFS9U4;Database=CliniqqDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating
        (
            ModelBuilder modelBuilder
        )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);
        }
    }
}