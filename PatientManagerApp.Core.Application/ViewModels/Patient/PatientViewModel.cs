﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.ViewModels.Patient
{
    public class PatientViewModel
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasAlergies { get; set; }
        public int ClinicId { get; set; }
        public string PicturePath { get; set; }
    }
}
