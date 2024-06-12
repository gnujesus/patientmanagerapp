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

        public async Task<SaveDoctorViewModel> Insert(SaveDoctorViewModel vm)
        {
            Doctor doctor = new()
            {
                Name = vm.Name,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
                PicturePath = vm.PicturePath,
                ClinicId = vm.ClinicId,
            };

            doctor = await _doctorRepository.InsertAsync(doctor);

            SaveDoctorViewModel doctorVm = new()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                LastName = doctor.LastName,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                PicturePath = doctor.PicturePath,
                ClinicId = doctor.ClinicId,
            };

            return doctorVm;
        }

        public async Task Delete(int id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);
            await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task Update(SaveDoctorViewModel vm)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(vm.Id);
            doctor.Id = vm.Id;
            doctor.Name = vm.Name;
            doctor.LastName = vm.LastName;
            doctor.Email = vm.Email;
            doctor.PhoneNumber = vm.PhoneNumber;
            doctor.PicturePath = vm.PicturePath;
            doctor.ClinicId = vm.ClinicId;

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
                PicturePath = doctor.PicturePath
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
                PicturePath = doctor.PicturePath,
                ClinicId = doctor.ClinicId,
            };

            return vm;
        }

        // Explicit implementation to satisfy IGenericService
        async Task IGenericService<DoctorViewModel, SaveDoctorViewModel>.Insert(SaveDoctorViewModel vm)
        {
            await Insert(vm);
        }
    }
}
