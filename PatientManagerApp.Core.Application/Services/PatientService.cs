using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.Patient;
using PatientManagerApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepository<Patient> _patientRepository;

        public PatientService(IGenericRepository<Patient> repository)
        {
            _patientRepository = repository;
        }

        public async Task Insert(SavePatientViewModel vm)
        {
            Patient patient = new()
            {
                Name = vm.Name,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Address = vm.Address,
                BirthDate = vm.BirthDate,
                IsSmoker = vm.IsSmoker,
                HasAlergies = vm.HasAlergies,
                ClinicId = vm.ClinicId,
                Picture = vm.Picture
            };

            await _patientRepository.InsertAsync(patient);
        }

        public async Task Delete(int id)
        {
            Patient patient = await _patientRepository.GetByIdAsync(id);
            await _patientRepository.DeleteAsync(patient);
        }

        public async Task Update(SavePatientViewModel vm)
        {
            Patient patient = new()
            {
                Id = vm.Id,
                Name = vm.Name,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Address = vm.Address,
                BirthDate = vm.BirthDate,
                IsSmoker = vm.IsSmoker,
                HasAlergies = vm.HasAlergies,
                ClinicId = vm.ClinicId,
                Picture = vm.Picture
            };

            await _patientRepository.UpdateAsync(patient);
        }

        public async Task<List<PatientViewModel>> GetAllViewModelAsync()
        {
            List<Patient> patientList = await _patientRepository.GetAllAsync();

            return patientList.Select(patient => new PatientViewModel
            {
                Id = patient.Id,
                Name = patient.Name,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
                BirthDate = patient.BirthDate,
                IsSmoker = patient.IsSmoker,
                HasAlergies = patient.HasAlergies,
                ClinicId = patient.ClinicId,
                Picture = patient.Picture
            }).ToList();
        }

        public async Task<SavePatientViewModel> GetByIdCreateViewModel(int id)
        {
            Patient patient = await _patientRepository.GetByIdAsync(id);
            SavePatientViewModel vm = new()
            {
                Id = patient.Id,
                Name = patient.Name,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
                BirthDate = patient.BirthDate,
                IsSmoker = patient.IsSmoker,
                HasAlergies = patient.HasAlergies,
                ClinicId = patient.ClinicId,
                Picture = patient.Picture
            };

            return vm;
        }
    }
}
