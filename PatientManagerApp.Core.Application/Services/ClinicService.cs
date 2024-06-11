using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.Clinic;
using PatientManagerApp.Core.Domain.Entities;

namespace PatientManagerApp.Core.Application.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IGenericRepository<Clinic> _clinicRepository;

        public ClinicService(IGenericRepository<Clinic> repository)
        {
            _clinicRepository = repository;
        }

        public async Task Insert(SaveClinicViewModel vm)
        {
            Clinic clinic = new();

            await _clinicRepository.InsertAsync(clinic);
        }

        public async Task<Clinic> InsertAndReturn(SaveClinicViewModel vm)
        {
            Clinic clinic = new();

            return await _clinicRepository.InsertAsync(clinic);
        }


        public async Task Delete(int id)
        {
            Clinic clinic = await _clinicRepository.GetByIdAsync(id);
            await _clinicRepository.DeleteAsync(clinic);
        }

        public async Task<List<ClinicViewModel>> GetAllViewModelAsync()
        {
            List<Clinic> clinicList = await _clinicRepository.GetAllAsync();

            return clinicList.Select(clinic => new ClinicViewModel
            {
                Id = clinic.Id,
                // Map other properties as needed
            }).ToList();
        }

        public async Task<SaveClinicViewModel> GetByIdCreateViewModel(int id)
        {
            Clinic clinic = await _clinicRepository.GetByIdAsync(id);
            SaveClinicViewModel vm = new()
            {
                Id = clinic.Id,
                // Map other properties as needed
            };

            return vm;
        }

        public Task Update(SaveClinicViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
