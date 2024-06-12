namespace PatientManagerApp.Core.Domain.Entities
{
    public class Doctor:BaseEntity
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
       public string PhoneNumber { get; set; } 
       public string PicturePath { get; set; } 
       public int ClinicId { get; set; } 

       public ICollection<Appointment>? Appointments{ get; set; }



    }
}
