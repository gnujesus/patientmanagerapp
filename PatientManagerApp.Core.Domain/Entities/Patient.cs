namespace PatientManagerApp.Core.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber {  get; set; }
        public string Address {  get; set; }
        public DateTime BirthDate {  get; set; }
        public bool IsSmoker {  get; set; }
        public bool HasAlergies {  get; set; }
        public int ClinicId { get; set; }

        // No idea on how am I going to do this
        public string Picture { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<LaboratoryResult>? LaboratoryResults { get; set; }
    }
}
