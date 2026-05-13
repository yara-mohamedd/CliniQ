using Cliniq.BLL.Services.Abstraction;
using Cliniq.BLL.Services.Implementation;
using Cliniq.DAL.Repo.Abstraction;
using Cliniq.DAL.Repo.Implementation;

namespace Cliniq.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IPatientRepo, PatientRepo>();

            builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();


            // =========================
            // Services
            // =========================

            builder.Services.AddScoped<IPatientService, PatientService>();

            builder.Services.AddScoped<IAppointmentService, AppointmentService>();

            builder.Services.AddScoped<IDashboardService, DashboardService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Dashboard}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
