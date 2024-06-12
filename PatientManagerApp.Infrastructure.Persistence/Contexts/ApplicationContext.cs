using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PatientManagerApp.Core.Application.ViewModels.LaboratoryTest;
using PatientManagerApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext:DbContext
    {
        public  ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<User> Users{ get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<LaboratoryResult> LaboratoryResults { get; set; }
        public DbSet<LaboratoryTest> LaboratoryTests { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Fluent API
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Clinic>().ToTable("Clinics");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<LaboratoryResult>().ToTable("LaboratoryResults");
            modelBuilder.Entity<LaboratoryTest>().ToTable("LaboratoryTests");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            #endregion 

            #region Primary Keys
            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
            modelBuilder.Entity<Clinic>().HasKey(c => c.Id);
            modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            modelBuilder.Entity<LaboratoryResult>().HasKey(lr => lr.Id);
            modelBuilder.Entity<LaboratoryTest>().HasKey(lt => lt.Id);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            #endregion

            #region Property Configuration

            #region User 
            modelBuilder.Entity<User>()
                .Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(a => a.UserType)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(a => a.ClinicId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            #endregion

            #region Appointment
            modelBuilder.Entity<Appointment>()
                .Property(a => a.AppointmentDate)
                .IsRequired()
                .HasColumnType("datetime");

            modelBuilder.Entity<Appointment>()
                .Property(a => a.ReasonForTheAppointment)
                .HasMaxLength(500);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(50);
            #endregion

            #region Clinic
            modelBuilder.Entity<Clinic>()
                .Property(c => c.Id)
                .IsRequired();
            #endregion

            #region Doctor
            modelBuilder.Entity<Doctor>()
                .Property(d => d.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.PicturePath)
                .HasMaxLength(255);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.ClinicId)
                .IsRequired();

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            #endregion

            #region LaboratoryResult
            modelBuilder.Entity<LaboratoryResult>()
                .Property(lr => lr.PatientId)
                .IsRequired();
            #endregion

            #region LaboratoryTest
            modelBuilder.Entity<LaboratoryTest>()
                .Property(lt => lt.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<LaboratoryTest>()
                .Property(lt => lt.ClinicId)
                .IsRequired();
            #endregion

            #region Patient
            modelBuilder.Entity<Patient>()
                .Property(p => p.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(200);

            modelBuilder.Entity<Patient>()
                .Property(p => p.BirthDate)
                .HasColumnType("date");

            modelBuilder.Entity<Patient>()
                .Property(p => p.IsSmoker)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.HasAlergies)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.PicturePath)
                .HasMaxLength(255);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Patient>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Patient>()
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            #endregion

            #endregion

            #region Foreign Keys

            // Administrator -> Clinic
            modelBuilder.Entity<User>()
                .HasOne<Clinic>()
                .WithMany(c => c.Users)
                .HasForeignKey(a => a.ClinicId);

            // Appointment -> Doctor
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            // Appointment -> Patient
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            // Doctor -> Clinic
            modelBuilder.Entity<Doctor>()
                .HasOne<Clinic>()
                .WithMany(c => c.Doctors)
                .HasForeignKey(d => d.ClinicId);

            // LaboratoryResult -> Patient
            modelBuilder.Entity<LaboratoryResult>()
                .HasOne(lr => lr.Patient)
                .WithMany(p => p.LaboratoryResults)
                .HasForeignKey(lr => lr.PatientId);

            // LaboratoryTest -> Clinic
            modelBuilder.Entity<LaboratoryTest>()
                .HasOne<Clinic>()
                .WithMany(c => c.LaboratoryTests)
                .HasForeignKey(lt => lt.ClinicId);

            // Patient -> Clinic
            modelBuilder.Entity<Patient>()
                .HasOne<Clinic>()
                .WithMany(c => c.Patients)
                .HasForeignKey(p => p.ClinicId);

            #endregion

        }


    }
}
