using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.Services;

namespace PatientManagerApp.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IClinicService, ClinicService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<ILaboratoryResultService, LaboratoryResultService>();
            services.AddTransient<ILaboratoryTestService, LaboratoryTestService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
