using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PatientManagerApp.Core.Application.ViewModels.Patient
{
    public class SavePatientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address required")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Birth Date required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool IsSmoker { get; set; } = false;
        public bool HasAlergies { get; set; } = false;
        public int ClinicId { get; set; }
        public string PicturePath { get; set; } = string.Empty;

        [Required(ErrorMessage = "A picture is required")]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
