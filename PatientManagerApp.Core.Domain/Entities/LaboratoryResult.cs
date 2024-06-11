namespace PatientManagerApp.Core.Domain.Entities
{
    public class LaboratoryResult : BaseEntity
    {
        public string Results { get; set; }
        public int PatientId {  get; set; }
        public int ClinicId { get; set; }

        public Patient? Patient { get; set; }

    }
}
