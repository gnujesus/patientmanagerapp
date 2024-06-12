using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.LaboratoryResult;
using PatientManagerApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Services
{
    public class LaboratoryResultService : ILaboratoryResultService
    {
        private readonly IGenericRepository<LaboratoryResult> _laboratoryResultRepository;

        public LaboratoryResultService(IGenericRepository<LaboratoryResult> repository)
        {
            _laboratoryResultRepository = repository;
        }

        public async Task Insert(SaveLaboratoryResultViewModel vm)
        {
            LaboratoryResult result = new()
            {
                PatientId = vm.PatientId,
                ClinicId = vm.ClinicId,
                Results = vm.Results,
                Status = vm.Status
            };

            await _laboratoryResultRepository.InsertAsync(result);
        }

        public async Task Delete(int id)
        {
            LaboratoryResult result = await _laboratoryResultRepository.GetByIdAsync(id);
            await _laboratoryResultRepository.DeleteAsync(result);
        }

        public async Task Update(SaveLaboratoryResultViewModel vm)
        {
            LaboratoryResult result = new()
            {
                Id = vm.Id,
                PatientId = vm.PatientId,
                ClinicId = vm.ClinicId,
                Results = vm.Results,
                Status = vm.Status
            };

            await _laboratoryResultRepository.UpdateAsync(result);
        }

        public async Task<List<LaboratoryResultViewModel>> GetAllViewModelAsync()
        {
            List<LaboratoryResult> resultList = await _laboratoryResultRepository.GetAllAsync();

            return resultList.Select(result => new LaboratoryResultViewModel
            {
                Id = result.Id,
                PatientId = result.PatientId,
                ClinicId = result.ClinicId,
                Results = result.Results,
                Status = result.Status
            }).ToList();
        }

        public async Task<SaveLaboratoryResultViewModel> GetByIdCreateViewModel(int id)
        {
            LaboratoryResult result = await _laboratoryResultRepository.GetByIdAsync(id);
            SaveLaboratoryResultViewModel vm = new()
            {
                Id = result.Id,
                PatientId = result.PatientId,
                ClinicId = result.ClinicId,
                Results = result.Results,
                Status = result.Status
            };

            return vm;
        }
    }
}
