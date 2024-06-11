using PatientManagerApp.Core.Application.ViewModels.Appointment;

namespace PatientManagerApp.Core.Application.Interfaces.Services
{
    public interface IAppointmentService : IGenericService<AppointmentViewModel, SaveAppointmentViewModel> { }
}