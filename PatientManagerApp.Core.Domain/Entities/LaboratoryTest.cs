namespace PatientManagerApp.Core.Domain.Entities
{
    public class LaboratoryTest : BaseEntity
    {
        public string Name { get; set; }
        public int ClinicId { get; set; }
    }
}
