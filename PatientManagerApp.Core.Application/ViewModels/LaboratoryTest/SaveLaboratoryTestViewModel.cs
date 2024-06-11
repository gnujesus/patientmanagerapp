using System.ComponentModel.DataAnnotations;

namespace PatientManagerApp.Core.Application.ViewModels.LaboratoryTest
{
    public class SaveLaboratoryTestViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, introduce a valid name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public int ClinicId { get; set; }
    }
}
