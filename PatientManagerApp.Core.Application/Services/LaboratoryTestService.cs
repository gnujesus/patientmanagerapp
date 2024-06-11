using Microsoft.AspNetCore.Http;
using PatientManagerApp.Core.Application.Helpers;
using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.LaboratoryTest;
using PatientManagerApp.Core.Application.ViewModels.User;
using PatientManagerApp.Core.Domain.Entities;

namespace PatientManagerApp.Core.Application.Services
{
    public class LaboratoryTestService : ILaboratoryTestService
    {
        private readonly IGenericRepository<LaboratoryTest> _laboratoryTestRepository;

        public LaboratoryTestService(IGenericRepository<LaboratoryTest> repository)
        {
            _laboratoryTestRepository = repository;
        }

        public async Task Insert(SaveLaboratoryTestViewModel vm)
        {
            LaboratoryTest test = new()
            {
                Name = vm.Name,
                ClinicId = vm.ClinicId
            };

            await _laboratoryTestRepository.InsertAsync(test);
        }

        public async Task Delete(int id)
        {
            LaboratoryTest test = await _laboratoryTestRepository.GetByIdAsync(id);
            await _laboratoryTestRepository.DeleteAsync(test);
        }

        public async Task Update(SaveLaboratoryTestViewModel vm)
        {
            LaboratoryTest test = new()
            {
                Id = vm.Id,
                Name = vm.Name,
                ClinicId = vm.ClinicId
            };

            await _laboratoryTestRepository.UpdateAsync(test);
        }

        public async Task<List<LaboratoryTestViewModel>> GetAllViewModelAsync()
        {
            List<LaboratoryTest> testList = await _laboratoryTestRepository.GetAllAsync();

            return testList.Select(test => new LaboratoryTestViewModel
            {
                Id = test.Id,
                Name = test.Name,
                ClinicId = test.ClinicId
            }).ToList();
        }

        public async Task<SaveLaboratoryTestViewModel> GetByIdCreateViewModel(int id)
        {
            LaboratoryTest test = await _laboratoryTestRepository.GetByIdAsync(id);
            SaveLaboratoryTestViewModel vm = new()
            {
                Id = test.Id,
                Name = test.Name,
                ClinicId = test.ClinicId
            };

            return vm;
        }
    }
}
