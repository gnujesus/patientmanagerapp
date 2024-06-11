using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.Doctor;
using PatientManagerApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IGenericRepository<Doctor> _doctorRepository;

        public DoctorService(IGenericRepository<Doctor> repository)
        {
            _doctorRepository = repository; 
        }

        public async Task Insert(SaveDoctorViewModel vm)
        {
            Doctor doctor = new()
            {
                Name = vm.Name,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Picture = vm.Picture,
                ClinicId = vm.ClinicId,
            };

            await _doctorRepository.InsertAsync(doctor);
        }

        public async Task Delete(int id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);
            await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task Update(SaveDoctorViewModel vm)
        {
            Doctor doctor = new()
            {
                Id = vm.Id,
                Name = vm.Name,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                Picture = vm.Picture,
                ClinicId = vm.ClinicId,
            };

            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task<List<DoctorViewModel>> GetAllViewModelAsync()
        {
            List<Doctor> doctorList = await _doctorRepository.GetAllAsync();

            return doctorList.Select(doctor => new DoctorViewModel
            {
                Id = doctor.Id,
                Name = doctor.Name,
                LastName = doctor.LastName,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                ClinicId = doctor.ClinicId,
                Picture = doctor.Picture
            }).ToList();
        }

        public async Task<SaveDoctorViewModel> GetByIdCreateViewModel(int id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);
            SaveDoctorViewModel vm = new()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                LastName = doctor.LastName,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                Picture = doctor.Picture,
                ClinicId = doctor.ClinicId,
            };

            return vm;
        }
    }
}
