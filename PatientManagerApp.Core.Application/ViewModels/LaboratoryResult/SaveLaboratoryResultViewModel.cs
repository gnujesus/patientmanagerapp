using PatientManagerApp.Core.Domain.Entities;

namespace PatientManagerApp.Core.Application.ViewModels.LaboratoryResult
{
    public class SaveLaboratoryResultViewModel
    {
        public int Id { get; set; }
        public string Results { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public int ClinicId { get; set; }
        public string Status { get; set; } = "pending";
        public List<int> LaboratoryTests { get; set; } = new List<int>();

    }
}
