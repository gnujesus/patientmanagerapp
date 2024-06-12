﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientManagerApp.Infrastructure.Persistence.Contexts;

#nullable disable

namespace PatientManagerApp.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240612184332_AddedNavegationPropertyToLaboratoryResult")]
    partial class AddedNavegationPropertyToLaboratoryResult
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("ReasonForTheAppointment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clinics", (string)null);
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.LaboratoryResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Results")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("PatientId");

                    b.ToTable("LaboratoryResults", (string)null);
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.LaboratoryTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<int?>("LaboratoryResultId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("LaboratoryResultId");

                    b.ToTable("LaboratoryTests", (string)null);
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("HasAlergies")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSmoker")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("PatientManagerApp.Core.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientManagerApp.Core.Domain.Entities.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("PatientManagerApp.Core.Domain.Entities.Clinic", null)
                        .WithMany("Doctors")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.LaboratoryResult", b =>
                {
                    b.HasOne("PatientManagerApp.Core.Domain.Entities.Clinic", null)
                        .WithMany("LaboratoryResults")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientManagerApp.Core.Domain.Entities.Patient", "Patient")
                        .WithMany("LaboratoryResults")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.LaboratoryTest", b =>
                {
                    b.HasOne("PatientManagerApp.Core.Domain.Entities.Clinic", null)
                        .WithMany("LaboratoryTests")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientManagerApp.Core.Domain.Entities.LaboratoryResult", null)
                        .WithMany("LaboratoryTests")
                        .HasForeignKey("LaboratoryResultId");
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Patient", b =>
                {
                    b.HasOne("PatientManagerApp.Core.Domain.Entities.Clinic", null)
                        .WithMany("Patients")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.User", b =>
                {
                    b.HasOne("PatientManagerApp.Core.Domain.Entities.Clinic", null)
                        .WithMany("Users")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Clinic", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("LaboratoryResults");

                    b.Navigation("LaboratoryTests");

                    b.Navigation("Patients");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.LaboratoryResult", b =>
                {
                    b.Navigation("LaboratoryTests");
                });

            modelBuilder.Entity("PatientManagerApp.Core.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("LaboratoryResults");
                });
#pragma warning restore 612, 618
        }
    }
}
