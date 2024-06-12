using PatientManagerApp.Core.Domain.Entities;

namespace PatientManagerApp.Core.Application.ViewModels.LaboratoryResult
{
    public class LaboratoryResultViewModel
    {
        public int Id { get; set; }
        public string Results { get; set; }
        public int PatientId { get; set; }
        public int ClinicId { get; set; }
        public string Status { get; set; }

    }
}
