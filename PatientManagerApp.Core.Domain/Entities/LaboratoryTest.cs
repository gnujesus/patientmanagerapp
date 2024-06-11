namespace PatientManagerApp.Core.Domain.Entities
{
    public class LaboratoryTest : BaseEntity
    {
        public int Name { get; set; }
        public int ClinicId { get; set; }
    }
}
