using PatientManagerApp.Core.Application.ViewModels.LaboratoryTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Interfaces.Services
{
    public interface ILaboratoryTestService : IGenericService<LaboratoryTestViewModel, SaveLaboratoryTestViewModel>
    {
    }
}
