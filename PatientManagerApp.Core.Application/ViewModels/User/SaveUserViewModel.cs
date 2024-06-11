using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagerApp.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        // Pending validations
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, introduce a valid name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, introduce a valid name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, introduce a valid username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please, povide a valid email")]
        [DataType(DataType.Password)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, provide a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords must be the same")]
        [Required(ErrorMessage = "Please, introduce a valid Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        // Doesn't require a validation since it's a dropdown or automatically creates an admin
        public string? UserType { get; set; }

        // Doesn't require a validation since the clinic will be created along with the admin, unless it's 
        // an assistant, in such case it's ClinicId will be the same as the admins'
        public int ClinicId { get; set; }
    }
}
