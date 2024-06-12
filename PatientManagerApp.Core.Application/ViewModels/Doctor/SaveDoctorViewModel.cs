using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.ViewModels.Doctor
{
    public class SaveDoctorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        public string PicturePath { get; set; } = string.Empty;

        public int ClinicId { get; set; }

        [Required(ErrorMessage = "A picture is required")]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
