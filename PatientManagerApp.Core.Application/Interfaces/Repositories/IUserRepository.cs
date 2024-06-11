using PatientManagerApp.Core.Application.ViewModels.User;
using PatientManagerApp.Core.Domain.Entities;

namespace PatientManagerApp.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> LoginAsync(LoginUserViewModel loginUserViewModel);
    }
}
