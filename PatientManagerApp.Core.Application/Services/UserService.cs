using PatientManagerApp.Core.Application.Enums;
using PatientManagerApp.Core.Application.Helpers;
using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.User;
using PatientManagerApp.Core.Domain.Entities;

namespace PatientManagerApp.Core.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IGenericRepository<Clinic> _clinicRepository;

        public UserService(IUserRepository userRepository, IGenericRepository<Clinic> clinicRepository)
        {
            _userRepository = userRepository;
            _clinicRepository = clinicRepository;
        }

        public async Task Insert(SaveUserViewModel vm)
        {

            // Encryptation
            string password = EncryptationHelper.ComputeSha256Hash(vm.Password);

            User user = new()
            {
                Name = vm.Name,
                LastName = vm.LastName,
                Username = vm.Username,
                Email = vm.Email,
                UserType = vm.UserType,
                ClinicId = vm.ClinicId,
                Password = password 
            };

            // Default usertype
            if (user.UserType == null)
            {
                user.UserType = UsersEnum.Admin.ToString();
            }

            // New clinic if doesn't exist
            if(user.ClinicId == 0)
            {
                Clinic clinic = new() { };
                clinic = await _clinicRepository.InsertAsync(clinic);
                user.ClinicId = clinic.Id;
            }

            await _userRepository.InsertAsync(user);
        }

        public async Task Delete(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserViewModel> Login(LoginUserViewModel loginUserViewModel)
        {

            User user = await _userRepository.LoginAsync(loginUserViewModel);

            if(user == null)
            {
                return null;
            }

            UserViewModel userViewModel = new()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                ClinicId = user.ClinicId,
                UserType = user.UserType,
            };

            return userViewModel;
        }

        public async Task Update(SaveUserViewModel vm)
        {

            User user = new()
            {
                Name = vm.Name,
                LastName = vm.LastName,
                Username = vm.Username,
                Email = vm.Email,
                UserType = vm.UserType,
                ClinicId = vm.ClinicId,
                Password = vm.Password
            };

            await _userRepository.UpdateAsync(user);
        }
        public async Task<List<UserViewModel>> GetAllViewModelAsync()
        {
            List<User> userList = await _userRepository.GetAllAsync();

            return userList.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
            }).ToList();
        }

        public async Task<SaveUserViewModel> GetByIdCreateViewModel(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            SaveUserViewModel vm = new()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                UserType = user.UserType,
                ClinicId = user.ClinicId
            };

            return vm;
        }

    }
}
