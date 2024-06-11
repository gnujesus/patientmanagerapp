using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Interfaces.Services
{
    public interface IGenericService<ViewModel, SaveViewModel>
        where ViewModel : class
        where SaveViewModel : class
    {
        Task<List<ViewModel>> GetAllViewModelAsync();
        Task<SaveViewModel> GetByIdCreateViewModel(int id);
        Task Insert(SaveViewModel vm);
        Task Update(SaveViewModel vm);
        Task Delete(int id);
    }
}
