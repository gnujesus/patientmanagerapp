using PatientManagerApp.Core.Application.ViewModels.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Interfaces.Services
{
    public interface IDoctorService : IGenericService<DoctorViewModel, SaveDoctorViewModel> { }
}
