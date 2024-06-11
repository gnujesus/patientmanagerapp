using PatientManagerApp.Core.Domain.Entities;

namespace PatientManagerApp.Core.Application.ViewModels.LaboratoryResult
{
    public class SaveLaboratoryResultViewModel
    {
        public int Id { get; set; }
        public string Results { get; set; }
        public int PatientId { get; set; }
        public int ClinicId { get; set; }


    }
}
