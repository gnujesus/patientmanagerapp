using PatientManagerApp.Core.Application.Interfaces.Repositories;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.Appointment;
using PatientManagerApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IGenericRepository<Appointment> _appointmentRepository;

        public AppointmentService(IGenericRepository<Appointment> repository)
        {
            _appointmentRepository = repository;
        }

        public async Task Insert(SaveAppointmentViewModel vm)
        {
            Appointment appointment = new()
            {
                PatientId = vm.PatientId,
                DoctorId = vm.DoctorId,
                AppointmentDate = vm.AppointmentDate,
                ReasonForTheAppointment = vm.ReasonForTheAppointment,
                Status = vm.Status
            };

            await _appointmentRepository.InsertAsync(appointment);
        }

        public async Task Delete(int id)
        {
            Appointment appointment = await _appointmentRepository.GetByIdAsync(id);
            await _appointmentRepository.DeleteAsync(appointment);
        }

        public async Task Update(SaveAppointmentViewModel vm)
        {
            Appointment appointment = new()
            {
                Id = vm.Id,
                PatientId = vm.PatientId,
                DoctorId = vm.DoctorId,
                AppointmentDate = vm.AppointmentDate,
                ReasonForTheAppointment = vm.ReasonForTheAppointment,
                Status = vm.Status
            };

            await _appointmentRepository.UpdateAsync(appointment);
        }

        public async Task<List<AppointmentViewModel>> GetAllViewModelAsync()
        {
            List<Appointment> appointmentList = await _appointmentRepository.GetAllAsync();

            return appointmentList.Select(appointment => new AppointmentViewModel
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                ReasonForTheAppointment = appointment.ReasonForTheAppointment,
                Status = appointment.Status,
            }).ToList();
        }

        public async Task<SaveAppointmentViewModel> GetByIdCreateViewModel(int id)
        {
            Appointment appointment = await _appointmentRepository.GetByIdAsync(id);
            SaveAppointmentViewModel vm = new()
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                ReasonForTheAppointment = appointment.ReasonForTheAppointment,
                Status = appointment.Status
            };

            return vm;
        }
    }
}
