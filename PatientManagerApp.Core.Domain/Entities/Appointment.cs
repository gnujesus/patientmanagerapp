using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Domain.Entities
{
    // Initially named consultation, but found a better word
    public class Appointment : BaseEntity
    {
        public int PatientId {  get; set; }
        public int DoctorId {  get; set; }
        public DateTime AppointmentDate {  get; set; }
        public string ReasonForTheAppointment {  get; set; }
        public string Status {  get; set; }

        // Navegation properties
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
