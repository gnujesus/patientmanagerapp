using System;
using System.Collections.Generic;
using System.Linq;
namespace PatientManagerApp.Core.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public ICollection<User>? Users{ get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
        public ICollection<Patient>? Patients { get; set; }
        public ICollection<LaboratoryTest>? LaboratoryTests{ get; set;}
        public ICollection<LaboratoryResult>? LaboratoryResults { get; set;}
    }
}
