using PatientManagerApp.Core.Application.ViewModels.Clinic;
using PatientManagerApp.Core.Domain.Entities;

namespace PatientManagerApp.Core.Application.Interfaces.Services
{
    public interface IClinicService : IGenericService<ClinicViewModel, SaveClinicViewModel> 
    {
        public Task<Clinic> InsertAndReturn(SaveClinicViewModel vm);
    }
}
