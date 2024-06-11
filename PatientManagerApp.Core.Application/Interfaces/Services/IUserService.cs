using PatientManagerApp.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<UserViewModel, SaveUserViewModel> 
    {
        public Task<UserViewModel> Login(LoginUserViewModel loginUserViewModel);
    }
}
