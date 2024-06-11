using PatientManagerApp.Core.Application.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Interfaces.Services
{
    public interface IPatientService : IGenericService<PatientViewModel, SavePatientViewModel>
    {
    }
}
